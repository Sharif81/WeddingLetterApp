using System.ComponentModel.DataAnnotations;

namespace WeddingLetter.Data
{
    public class Venues
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
