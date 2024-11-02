using System.ComponentModel.DataAnnotations;

namespace WeddingLetter.Data
{
    public class Packages : BaseEntities
    {
      
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }        
    }
}
