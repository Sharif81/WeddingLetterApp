using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeddingLetter.Models;
using WeddingLetter.Repository;

namespace WeddingLetter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramsController : ControllerBase
    {
        private readonly IProgramsRepository _programsRepository;
        public ProgramsController(IProgramsRepository programsRepository)
        {
            _programsRepository = programsRepository;
        }

        //Get API
        [HttpGet("")]
        public async Task<IActionResult> GetAllPrograms()
        {
            var programs = await _programsRepository.GetAllProgramsAsync();
            return Ok(programs);
        }

        //Get API By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgramsById([FromRoute] int id)
        {
            var program = await _programsRepository.GetProgramsByIdAsync(id);
            if(program == null)
            {
                return NotFound();
            }else
            {
                return Ok(program);
            }
        }

        //Add API
        [HttpPost("")]
        public async Task<ActionResult<ProgramsModel>> AddNewPrograms([FromBody] ProgramsModel programsModel)
        {
            var createdProgram = await _programsRepository.AddNewProgramsAsync(programsModel);
            return CreatedAtAction(nameof(GetProgramsById), new { id = createdProgram.Id}, createdProgram);
        }

    }
}
