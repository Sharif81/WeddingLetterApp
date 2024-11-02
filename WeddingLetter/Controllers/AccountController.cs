using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WeddingLetter.DTOs;
using WeddingLetter.Models;
using WeddingLetter.Repository;

namespace WeddingLetter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDTO signUpDTO)
        {
            var result = await _accountRepository.SignUpAsync(signUpDTO);

            if (result.Succeeded)
            {
                return Ok (new AuthResponseDTO { Success = true});
            }
            return BadRequest(new AuthResponseDTO
            {
                Success = false,
                Errors = result.Errors.Select(e => e.Description)
            });
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] SignInDTO signInDTO)
        {
            var toekn = await _accountRepository.LoginAsync(signInDTO);

            if (string.IsNullOrEmpty(toekn))
            {
                return Unauthorized(new AuthResponseDTO { Success = false});
            }
            return Ok(new AuthResponseDTO { Success = true, Token = toekn});
        }

        [HttpGet("username-exists/{username}")]
        [AllowAnonymous]
        public async Task<IActionResult> UsernameExists(string username)
        {
            var exists = await _accountRepository.UsernameExitsAsync(username);
            return Ok(new {exists});
        }
    }
}
