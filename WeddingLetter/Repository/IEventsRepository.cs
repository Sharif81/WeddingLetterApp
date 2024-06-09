using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingLetter.Data;
using WeddingLetter.Models;

namespace WeddingLetter.Repository
{
    public interface IEventsRepository
    {
        Task<List<EventsModel>> GetlAllEventsWithProgramsAsync();
        Task<EventsModel> GetEventsByIdAsync(int eventsId);
        Task<EventsModel> AddEventsAsync(EventsModel eventsModel);
    }
}
