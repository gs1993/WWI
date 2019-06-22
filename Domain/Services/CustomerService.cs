using AutoMapper;
using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CustomerService : ServiceBase, ICustomerService
    {
        public CustomerService(WideWorldImportersEntities db) : base(db)
        {
        }

        public async Task<IEnumerable<CustumerListDto>> GetPage(int pageNumber, int pageSize,
            string customerName, string customerCategory)
        {
            if (pageNumber < 1)
                pageNumber = 1;

            int skip = (pageNumber - 1) * pageSize;

            var customers = Context.Customers.Include("CustomerCategory").AsQueryable();

            if (!string.IsNullOrEmpty(customerName))
                customers = customers.Where(c => c.CustomerName.Contains(customerName));

            if (!string.IsNullOrEmpty(customerCategory))
                customers = customers.Where(c => c.CustomerCategory.CustomerCategoryName.Contains(customerCategory));

            customers = customers
                .OrderByDescending(c => c.CustomerID)
                .Skip(skip)
                .Take(pageSize);

            var result = Mapper.Map<List<CustumerListDto>>(customers.ToList());

            return result;
        }
    }
}
