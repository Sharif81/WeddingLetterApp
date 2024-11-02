using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WeddingLetter.DTOs;
using WeddingLetter.Models;

namespace WeddingLetter.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpDTO signUpDTO);
        Task<string> LoginAsync(SignInDTO signInDTO);
        // Task SignUpAsync(SignUpDTO signUpDTO);
        Task<bool> UsernameExitsAsync(string username);
    }
}
