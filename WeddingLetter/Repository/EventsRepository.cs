using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingLetter.Data;
using WeddingLetter.Models;

namespace WeddingLetter.Repository
{
    public class EventsRepository : IEventsRepository
    {
        private readonly WeddingLetterContext _context;
        private readonly IMapper _mapper;

        public EventsRepository(WeddingLetterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Get All - API
        public async Task<List<EventsModel>> GetlAllEventsWithProgramsAsync()
        {
           var events = await _context.Events.Include(e => e.Programs).OrderByDescending(e => e.Id).ToListAsync();
           var eventsModel = _mapper.Map<List<EventsModel>>(events);

            foreach(var eventModel in eventsModel)
            {
                eventModel.InvoiceID = GenerateInvoiceID(eventModel.Id, eventModel.Date);
            }

           return eventsModel;
           
        }

        //Method To Generate Invoice ID
        private string GenerateInvoiceID(int eventId, DateTime eventDate)
        {
           return $"INV{eventId}{eventDate:yy}";
        }

        //Get By ID - API
        public async Task<EventsModel> GetEventsByIdAsync(int eventsId)
        {
            var events = await _context.Events.FindAsync(eventsId);
            return _mapper.Map<EventsModel>(events);
        }

        //Add Event API
        public async Task<EventsModel> AddEventsAsync(EventsModel eventsModel)
        {
            var @evnts = _mapper.Map<Events>(eventsModel);
            _context.Events.Add(@evnts);
            await _context.SaveChangesAsync();

            return _mapper.Map<EventsModel>(@evnts);
        }
    }
}
