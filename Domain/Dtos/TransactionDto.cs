using System;

namespace Domain.Dtos
{
    public class TransactionListDto
    {
        public int CustomerTransactionID { get; set; }
        public int CustomerID { get; set; }
        public string PaymentMethodName { get; set; }
        public DateTime TransactionDate { get; set; }
        public string AmountExcludingTax { get; set; }
        public string TaxAmount { get; set; }
        public string TransactionAmount { get; set; }
        public string OutstandingBalance { get; set; }
        public DateTime? FinalizationDate { get; set; }
        public bool? IsFinalized { get; set; }
        public DateTime LastEditedWhen { get; set; }
    }
}
