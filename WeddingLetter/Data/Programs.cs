using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingLetter.Data
{
    public class Programs : BaseEntities
    {     
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string ProgramName { get; set; }
        [Required]
        public string Vanue { get; set; }      
        public int EventId { get; set; }

        [ForeignKey("EventId")]
        public Events Events { get; set; }
    }
}
