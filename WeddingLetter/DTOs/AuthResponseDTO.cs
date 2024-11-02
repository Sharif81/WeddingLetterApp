using System.Collections;
using System.Collections.Generic;

namespace WeddingLetter.DTOs
{
    public class AuthResponseDTO
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
