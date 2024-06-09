using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingLetter.Data;
using WeddingLetter.Models;

namespace WeddingLetter.Repository
{
    public class ProgramsRepository : IProgramsRepository
    {
        private readonly WeddingLetterContext _context;
        private readonly IMapper _mapper;
        public ProgramsRepository(WeddingLetterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }

        //Get API
        public async Task<List<ProgramsModel>> GetAllProgramsAsync()
        {
            var programs = await _context.Programs.ToListAsync();
            return _mapper.Map<List<ProgramsModel>>(programs);
        }


        //Get API By ID
        public async Task<ProgramsModel> GetProgramsByIdAsync(int programsId)
        {
            var program = await _context.Programs.FindAsync(programsId);
            return _mapper.Map<ProgramsModel>(program);
        }

        //ADD API
        public async Task<ProgramsModel> AddNewProgramsAsync(ProgramsModel programsModel)
        {
            var program = _mapper.Map<Programs>(programsModel);
            _context.Programs.Add(program);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProgramsModel>(program);
        }
    }
}
