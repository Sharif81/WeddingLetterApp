using System.ComponentModel.DataAnnotations.Schema;
using System;
using WeddingLetter.Data;

namespace WeddingLetter.Models
{
    public class PaymentsModel
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
