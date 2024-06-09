using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;

namespace WeddingLetter.Data
{
    public class Events
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string ClientName { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string EventName { get; set; }
        [Required]
        public string EventDescription { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int TotalEvent { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public decimal Discount { get; set; }
        [Required]
        public decimal PayableAmount { get; set; }
        public ICollection<Programs> Programs { get; set; }
       
    }
}
