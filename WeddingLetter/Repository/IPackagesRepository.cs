using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingLetter.Models;

namespace WeddingLetter.Repository
{
    public interface IPackagesRepository 
    {
        Task<List<PackagesModel>> GetAllPackagesAsync();
        Task<PackagesModel> GetPackagesByIdAsync(int packageId);
        Task<int> AddPackagesAsync(PackagesModel packagesModel);
        Task UpdatePackagesAsync(int packageId, PackagesModel packagesModel);
        Task UpdatePackagesByAsyncPartial(int packageId, JsonPatchDocument packagesModel);
        Task<bool> DeletePackageByIdAsync(int packageId);
    }
}
