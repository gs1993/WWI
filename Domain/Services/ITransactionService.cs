using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dtos;

namespace Domain.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionListDto>> Get(DateTime dateFrom, DateTime dateTo, int customerId);
        Task<DateTime> GetMinTransactionDate();
        Task<DateTime> GetMaxTransactionDate();
    }
}