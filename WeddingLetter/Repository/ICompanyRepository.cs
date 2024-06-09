using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingLetter.Models;

namespace WeddingLetter.Repository
{
    public interface ICompanyRepository
    {
        Task<List<CompanyModel>> GetAllCompanyAsync();
        Task<CompanyModel> GetCompanyByIdAsync(int companyId);
        Task<int> AddCompanyAsync(CompanyModel companyModel);
        Task UpdateCompanyAsync(int companyId, CompanyModel companyModel);
        Task UpdateCompanyByAsyncPartial(int companyId, JsonPatchDocument companyModal);       
        Task<bool> DeleteCompanyByIdAsync(int companyId);
    }
}
