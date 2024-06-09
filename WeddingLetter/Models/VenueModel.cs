using System.ComponentModel.DataAnnotations;

namespace WeddingLetter.Models
{
    public class VenueModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
