using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingLetter.Models;

namespace WeddingLetter.Repository
{
    public interface IVenueRepository
    {
        Task<List<VenueModel>> GetAllVenuesAsync();
        Task<VenueModel> GetVenueByIdAsync(int venueId);
        Task<int> AddVenuesAsync(VenueModel venueModel);
        Task UpdateVenueAsync(int venueId, VenueModel venueModel);
        Task UpdateVenueByAsyncPartial(int venueId, JsonPatchDocument packagesModel);
        Task<bool> DeleteVenueByIdAsync(int venueId);
    }
}
