using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dtos;

namespace Domain.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerListDto>> GetPage(DateTime dateFrom, DateTime dateTo,
             int[] customerCategoryIds, string customerName = "", int pageNumber = 1, int pageSize = 25);
    }
}