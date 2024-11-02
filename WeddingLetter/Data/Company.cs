using System.ComponentModel.DataAnnotations;

namespace WeddingLetter.Data
{
    public class Company : BaseEntities    {        
       
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
