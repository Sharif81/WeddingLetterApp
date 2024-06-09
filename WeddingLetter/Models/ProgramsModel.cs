using System.ComponentModel.DataAnnotations;
using System;
using WeddingLetter.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingLetter.Models
{
    public class ProgramsModel
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string ProgramName { get; set; }
        [Required]
        public string Vanue { get; set; }
        [ForeignKey("EventId")]
        public int EventId { get; set; }
        public EventsModel Events { get; set; }
    }
}
