using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingLetter.Models;

namespace WeddingLetter.Repository
{
    public interface IProgramsRepository
    {
        Task<List<ProgramsModel>> GetAllProgramsAsync();
        Task<ProgramsModel> GetProgramsByIdAsync(int programsId);
        Task<ProgramsModel> AddNewProgramsAsync(ProgramsModel programsModel);
    }
}
