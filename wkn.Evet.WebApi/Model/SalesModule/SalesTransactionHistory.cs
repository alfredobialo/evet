using System;

namespace wkn.Evet.WebApi.Model.SalesModule
{
    public class SalesTransactionHistory
    {
        public string InvoiceNo { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal? Total { get; set; } = 0.0m;
        public string Status { get; set; } = "DELIVERED";
        public string PaymentStatus { get; set; } = "INCOMPLETE";
    }
}