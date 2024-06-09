using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeddingLetter.Models;
using WeddingLetter.Repository;

namespace WeddingLetter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly IPackagesRepository _packagesRepository;

        public PackagesController(IPackagesRepository packagesRepository)
        {
            _packagesRepository = packagesRepository;
        }

        //Get API
        [HttpGet("")]
        public async Task<IActionResult> GetAllPackages()
        {
            var packages = await _packagesRepository.GetAllPackagesAsync();
            return Ok(packages);
        }

        //Get API by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPackageById([FromRoute] int id)
        {
            var package = await _packagesRepository.GetPackagesByIdAsync(id);
            if (package == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(package);
            }
        }

        //Add Packages - API

        [HttpPost("")]
        public async Task<IActionResult> AddNewPackage([FromBody] PackagesModel packagesModel)
        {
            var id = await _packagesRepository.AddPackagesAsync(packagesModel);
            return CreatedAtAction(nameof(GetPackageById), new { id = id, Controller = "Packages" }, id);
        }

        //Update Package - API

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePackage([FromBody] PackagesModel packagesModel, [FromRoute] int id)
        {
            await _packagesRepository.UpdatePackagesAsync(id, packagesModel);
            return Ok("Updated");
        }

        //Update Package Partial - API

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePackagePartial([FromBody] JsonPatchDocument packageModal, [FromRoute] int id)
        {
            await _packagesRepository.UpdatePackagesByAsyncPartial(id, packageModal);
            return Ok("Partial Updated");
        }

        //Delete Package - API

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackageById(int id)
        {
            var package = await _packagesRepository.DeletePackageByIdAsync(id);
            if (package)
            {
                return Ok(new { message = "Deleted" });
            }
            else
            {
                return NotFound(new {message = "Company Not Found"});
            }
        }

    }
}

