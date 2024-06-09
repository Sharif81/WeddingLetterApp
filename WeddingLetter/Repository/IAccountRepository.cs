using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WeddingLetter.Models;

namespace WeddingLetter.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModal);
        Task<string> LoginAsync(SignInModel signInModel);
    }
}
