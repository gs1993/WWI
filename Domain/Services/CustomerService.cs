using AutoMapper;
using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CustomerService : ServiceBase, ICustomerService
    {
        public static DateTime DefaultDateFrom = DateTime.Now.AddDays(-10).Date;
        public static DateTime DefaultDateTo = DateTime.Now.Date;

        public CustomerService(WideWorldImportersEntities db) : base(db)
        {
        }

        public async Task<int> GetCount(DateTime dateFrom, DateTime dateTo,
             int customerCategoryId, string customerName = "")
        {
            var customers = Context.Customers.Include("CustomerCategory").AsQueryable();

            if (customerCategoryId != 0)
                customers = customers.Where(c => c.CustomerCategoryID == customerCategoryId);

            if (!string.IsNullOrEmpty(customerName))
                customers = customers.Where(c => c.CustomerName.Contains(customerName));

            customers = customers.Where(c => dateFrom >= c.AccountOpenedDate && c.AccountOpenedDate <= dateTo);

            return await customers.CountAsync();
        }

        public async Task<IEnumerable<CustomerListDto>> GetPage(DateTime dateFrom, DateTime dateTo,
             int customerCategoryId, string customerName = "")
        {
            
            var customers = Context.Customers.Include("CustomerCategory").AsQueryable();

            if (customerCategoryId != 0)
                customers = customers.Where(c => c.CustomerCategoryID == customerCategoryId);

            if (!string.IsNullOrEmpty(customerName))
                customers = customers.Where(c => c.CustomerName.Contains(customerName));

            customers = customers.Where(c => dateFrom >= c.AccountOpenedDate && c.AccountOpenedDate <= dateTo);

            var result = await customers
                .OrderByDescending(c => c.CustomerID)
                .ToListAsync();

            var dto = Mapper.Map<List<CustomerListDto>>(result);

            return dto;
        }
    }
}
