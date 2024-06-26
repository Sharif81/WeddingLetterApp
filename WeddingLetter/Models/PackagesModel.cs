﻿using System.ComponentModel.DataAnnotations;

namespace WeddingLetter.Models
{
    public class PackagesModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }       
    }
}
