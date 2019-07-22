using AutoMapper;
using Dapper;
using Domain.Dtos;
using Domain.Models;
using Domain.Services.ConnectionStrings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class TransactionService : ITransactionService
    {
        IWwiConnectionStringService _connectionString;

        public TransactionService(IWwiConnectionStringService connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<TransactionListDto>> Get(DateTime dateFrom, DateTime dateTo, int customerId)
        {
            throw new Exception();
            //var transactions = await Context
            //    .Set<CustomerTransaction>()
            //    .AsNoTracking()
            //    .Where(t => t.TransactionDate >= dateFrom && t.TransactionDate <= dateTo && t.CustomerID == customerId)
            //    .ToListAsync();

            //return Mapper.Map<IEnumerable<TransactionListDto>>(transactions);
        }

        public async Task<DateTime> GetMinTransactionDate()
        {
            string sql = @"SELECT MIN([TransactionDate])
                           FROM [WideWorldImporters].[Sales].[CustomerTransactions]";
            var a = _connectionString.ConnectionStirng;
            using (var conn = new SqlConnection(a))
            {
                return await conn.QueryFirstAsync<DateTime>(sql);
            }
        }

        public async Task<DateTime> GetMaxTransactionDate()
        {
            string sql = @"SELECT MAX([TransactionDate])
                           FROM [WideWorldImporters].[Sales].[CustomerTransactions]";

            using (var conn = new SqlConnection(_connectionString.ConnectionStirng))
            {
                return await conn.QueryFirstAsync<DateTime>(sql);
            }
        }
    }
}
