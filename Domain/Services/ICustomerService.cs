using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dtos;

namespace Domain.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerListDto>> GetPage(DateTime dateFrom, DateTime dateTo,
             int customerCategoryId, string customerName = "");
        Task<int> GetCount(DateTime fromDate, DateTime toDate, int selectedCategoryId, string customerName);
    }
}