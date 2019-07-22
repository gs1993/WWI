using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ViewModels
{
    public class TransactionViewModel
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int CustomerId { get; set; }

        public List<TransactionListDto> Transactions { get; set; }

        public TransactionViewModel()
        {
            Transactions = new List<TransactionListDto>();
        }
    }
}