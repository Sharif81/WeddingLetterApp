using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingLetter.Data;
using WeddingLetter.Models;

namespace WeddingLetter.Repository
{
    public class PackagesRepository : IPackagesRepository
    {
        private readonly WeddingLetterContext _context;
        private readonly IMapper _mapper;

        public PackagesRepository(WeddingLetterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        //Get All - API
        public async Task<List<PackagesModel>> GetAllPackagesAsync()
        {
            var packages = await _context.Packages.ToListAsync();
            return _mapper.Map<List<PackagesModel>>(packages);
           
        }

        //Get by ID - API
        public async Task<PackagesModel> GetPackagesByIdAsync(int packageId)
        {
            var package = await _context.Packages.FindAsync(packageId);
            return _mapper.Map<PackagesModel>(package);
        }

        //Add Package - API
        public async Task<int> AddPackagesAsync(PackagesModel packagesModel)
        {
            var package = _mapper.Map<Packages>(packagesModel);
            _context.Packages.Add(package);
            await _context.SaveChangesAsync();
            return package.Id;
        }


        //Update API

        public async Task UpdatePackagesAsync(int packageId, PackagesModel packagesModel)
        {
            var package = _mapper.Map<PackagesModel, Packages>(packagesModel);
            package.Id = packageId;
            _context.Packages.Update(package);
            await _context.SaveChangesAsync();
        }

        //Update Packages API Using Patch
        public async Task UpdatePackagesByAsyncPartial(int packageId, JsonPatchDocument packagesModel)
        {
            var package = await _context.Packages.FindAsync(packageId);
            if(package != null)
            {
                packagesModel.ApplyTo(package);
                await _context.SaveChangesAsync();
            }
        }

        //Delete Package API
        public async Task<bool> DeletePackageByIdAsync(int packageId)
        {
            var package = await _context.Packages.FindAsync(packageId);
            if (package == null)
            {
                return false;
            }
            _context.Packages.Remove(package);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
