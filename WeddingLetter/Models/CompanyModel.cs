using System.ComponentModel.DataAnnotations;

namespace WeddingLetter.Models
{
    public class CompanyModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Mobile { get; set; }
    }
}
