using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingLetter.Data
{
    public class Payments
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string InvoiceId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public string PaidBy { get; set; }
        public decimal Due { get; set; }
        public int EventId { get; set; }      
    }
}
