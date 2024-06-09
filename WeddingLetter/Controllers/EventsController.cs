using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeddingLetter.Data;
using WeddingLetter.Models;
using WeddingLetter.Repository;

namespace WeddingLetter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventsRepository _eventsRepository;

        public EventsController(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        //Get All - API 
        [HttpGet("GetAllEventsWithPrograms")]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _eventsRepository.GetlAllEventsWithProgramsAsync();
            return Ok(events);
        }

        //Get API By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventsById([FromRoute] int id)
        {
            var events = await _eventsRepository.GetEventsByIdAsync(id);
            if(events == null)
            {
                return NotFound();
            }else
            {
                return Ok(events);
            }
        }


        //Add Events - API
        [HttpPost("")]
        public async Task<ActionResult<EventsModel>> AddNewEvents([FromBody] EventsModel eventsModel)
        {           
            var createdEvent = await _eventsRepository.AddEventsAsync(eventsModel);
            return CreatedAtAction(nameof(GetEventsById), new {id = createdEvent.Id}, createdEvent);
        }
    }
}
