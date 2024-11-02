using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeddingLetter.Models;
using WeddingLetter.Repository;

namespace WeddingLetter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository; 

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCompany() 
        {
            var companys = await _companyRepository.GetAllCompanyAsync();

            return Ok(companys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById([FromRoute] int id)
        {
            var company = await _companyRepository.GetCompanyByIdAsync(id);
            if(company == null)
            {
               return NotFound();
            }

            return Ok(company);
        }


        [HttpPost("")]
        public async Task<IActionResult> AddNewCompany([FromBody] CompanyModel companyModel)
        {
            var id = await _companyRepository.AddCompanyAsync(companyModel);
            return CreatedAtAction(nameof(GetCompanyById), new { id = id, controller = "Company" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany([FromBody] CompanyModel companyModel, [FromRoute] int id) 
        {
            await _companyRepository.UpdateCompanyAsync(id, companyModel);
            return Ok("Updated");
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCompanyPartial([FromBody] JsonPatchDocument companyModel, [FromRoute] int id)
        {
            await _companyRepository.UpdateCompanyByAsyncPartial(id, companyModel);
            return Ok("Partial Updated");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyById(int id)
        {
            var success = await _companyRepository.DeleteCompanyByIdAsync(id);

            if (success)
            {
                return Ok(new { message = "Deleted" });
            }
            else
            {
                return NotFound(new {message = "Company Not Found"}); // Or return a different appropriate status code
            }
        }

    }
}
