using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private WideWorldImportersEntities _db;

        public CustomerService(WideWorldImportersEntities db)
        {
            _db = db;
        }

        public async Task<IEnumerable<CustumerListDto>> GetPage(int pageNumber, int pageSize,
            string customerName, string customerCategory)
        {

            throw new NotImplementedException();
        }
    }
}
