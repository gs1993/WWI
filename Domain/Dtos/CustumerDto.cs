using System;

namespace Domain.Dtos
{
    public class CustomerListDto
    {
        private decimal standardDiscountPercentage;

        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCategoryName { get; set; }
        public Nullable<decimal> CreditLimit { get; set; }
        public string AccountOpenedDate { get; set; }
        public string StandardDiscountPercentage {
            get => $"{standardDiscountPercentage:P2}";
        }
        public bool IsStatementSent { get; set; }
        public bool IsOnCreditHold { get; set; }
        public int PaymentDays { get; set; }
    }

    public class CustomerDetailsDto
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCategoryName { get; set; }
        public Nullable<decimal> CreditLimit { get; set; }
        public string AccountOpenedDate { get; set; }
        public decimal StandardDiscountPercentage { get; set; }
        public bool IsStatementSent { get; set; }
        public bool IsOnCreditHold { get; set; }
        public int PaymentDays { get; set; }
    }
}
