using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingLetter.Data;
using WeddingLetter.Models;

namespace WeddingLetter.Repository
{
    public class VenueRepository : IVenueRepository
    {
        private readonly WeddingLetterContext _context;
        private readonly IMapper _mapper;

        public VenueRepository(WeddingLetterContext context, IMapper mapper)
        {
            _context = context;
           _mapper = mapper;
        }

        //Get All - API
        public async Task<List<VenueModel>> GetAllVenuesAsync()
        {
            var venues = await _context.Venues.ToListAsync();
            return _mapper.Map<List<VenueModel>>(venues);
        }

        //Get By ID - API
        public async Task<VenueModel> GetVenueByIdAsync(int venueId)
        {
            var venue = await _context.Venues.FindAsync(venueId);
            return _mapper.Map<VenueModel>(venue);

        }


        //ADD Venue - API
        public async Task<int> AddVenuesAsync(VenueModel venueModel)
        {
            var venue = _mapper.Map<Venues>(venueModel);
            _context.Venues.Add(venue);
            await _context.SaveChangesAsync();
            return venue.Id;
        }

        //Update API
        public async Task UpdateVenueAsync(int venueId, VenueModel venueModel)
        {
            var venue = _mapper.Map<VenueModel, Venues>(venueModel);
            venue.Id = venueId;
            _context.Venues.Update(venue);
            await _context.SaveChangesAsync();
        }

        //Update Venue API Using Patch
        public async Task UpdateVenueByAsyncPartial(int venueId, JsonPatchDocument packagesModel)
        {
            var venue = await _context.Venues.FindAsync(venueId);
            if (venue != null)
            {
                packagesModel.ApplyTo(venue);
                await _context.SaveChangesAsync();
            }
        }

        //Delete Venue API
        public async Task<bool> DeleteVenueByIdAsync(int venueId)
        {
            var venue = await _context.Venues.FindAsync(venueId);
            if (venue == null)
            {
                return false;
            }
            _context.Venues.Remove(venue);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
