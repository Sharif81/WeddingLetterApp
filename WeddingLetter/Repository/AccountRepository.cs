using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WeddingLetter.DTOs;
using WeddingLetter.Models;

namespace WeddingLetter.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        public async Task<IdentityResult> SignUpAsync(SignUpDTO signUpDTO)
        {
            if(await UsernameExitsAsync(signUpDTO.Email))
            {
                return IdentityResult.Failed(new IdentityError { Description = "Username already Exists" });
            }
            var user = new ApplicationUser()
            {
                FirstName = signUpDTO.FirstName,
                LastName = signUpDTO.LastName,
                Email = signUpDTO.Email,
                UserName = signUpDTO.Email
            };

           return await _userManager.CreateAsync(user, signUpDTO.Password);
        }

        public async Task<string> LoginAsync(SignInDTO signInDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(signInDTO.Email, signInDTO.Password, false, false);

            if (!result.Succeeded)
            {
                return null;
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, signInDTO.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var authSignInKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256Signature)
                );

           return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> UsernameExitsAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user != null;
        }

    }
}
