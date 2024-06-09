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
    public class VenueController : ControllerBase
    {
        private readonly IVenueRepository _venueRepository;

        public VenueController(IVenueRepository venueRepository)
        {
           _venueRepository = venueRepository;
        }
        //Get All - API
        [HttpGet("")]
        public async Task<IActionResult> GetAllVenues()
        {
            var venues = await _venueRepository.GetAllVenuesAsync();
            return Ok(venues);
        }


        //Get API by Id

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVenueById([FromRoute] int id)
        {
            var venue = await _venueRepository.GetVenueByIdAsync(id);
            if (venue == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(venue);
            }
        }

        //Add Venue - API

        [HttpPost("")]
        public async Task<IActionResult> AddNewVenue([FromBody] VenueModel venueModel)
        {
            var id = await _venueRepository.AddVenuesAsync(venueModel);
            return CreatedAtAction(nameof(GetVenueById), new { id = id, Controller = "Venue" }, id);
        }

        //Update Venue - API

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVenue([FromBody] VenueModel venueModel, [FromRoute] int id)
        {
            await _venueRepository.UpdateVenueAsync(id, venueModel);
            return Ok("Updated");
        }

        //Update Venue Partial - API

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateVenuePartial([FromBody] JsonPatchDocument venueModal, [FromRoute] int id)
        {
            await _venueRepository.UpdateVenueByAsyncPartial(id, venueModal);
            return Ok("Partial Updated");
        }

        //Delete Venue - API

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenueById(int id)
        {
            var venue = await _venueRepository.DeleteVenueByIdAsync(id);
            if (venue)
            {
                return Ok(new { message = "Deleted" });
            }
            else
            {
                return NotFound(new { message = "Company Not Found" });
            }
        }
    }
}
