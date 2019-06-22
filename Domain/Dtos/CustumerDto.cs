using System;

namespace Domain.Dtos
{
    public class CustumerListDto
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCategoryName { get; set; }
        public Nullable<decimal> CreditLimit { get; set; }
        public System.DateTime AccountOpenedDate { get; set; }
        public decimal StandardDiscountPercentage { get; set; }
        public bool IsStatementSent { get; set; }
        public bool IsOnCreditHold { get; set; }
        public int PaymentDays { get; set; }
    }
}
