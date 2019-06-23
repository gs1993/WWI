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
        public const int DefaultPageSize = 25;
        public static DateTime DefaultDateFrom = DateTime.Now.AddDays(-10).Date;
        public static DateTime DefaultDateTo = DateTime.Now.Date;

        public CustomerService(WideWorldImportersEntities db) : base(db)
        {
        }

        public async Task<IEnumerable<CustomerListDto>> GetPage(DateTime dateFrom, DateTime dateTo,
             int[] customerCategoryIds, string customerName = "", int pageNumber = 1, int pageSize = DefaultPageSize)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = DefaultPageSize;
            int skip = (pageNumber - 1) * pageSize;

            var customers = Context.Customers.Include("CustomerCategory").AsQueryable();

            if (customerCategoryIds?.Length > 0)
                customers = customers.Where(c => customerCategoryIds.Contains(c.CustomerCategoryID));

            if (!string.IsNullOrEmpty(customerName))
                customers = customers.Where(c => c.CustomerName.Contains(customerName));

            customers = customers.Where(c => dateFrom >= c.AccountOpenedDate && c.AccountOpenedDate <= dateTo);

            var result = await customers
                .OrderByDescending(c => c.CustomerID)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();

            var dto = Mapper.Map<List<CustomerListDto>>(result);

            return dto;
        }
    }
}
