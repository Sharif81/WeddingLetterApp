using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingLetter.Data;
using WeddingLetter.Models;

namespace WeddingLetter.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly WeddingLetterContext _context;
        private readonly IMapper _mapper;
        public CompanyRepository(WeddingLetterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Get All - API
        public async Task<IReadOnlyList<CompanyModel>> GetAllCompanyAsync()
        {
            // One way to find data
            //var companysRecords = await _context.Company.Select(x => new CompanyModel()
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Address = x.Address,
            //    Email = x.Email,
            //    Mobile = x.Mobile,
            //}).ToListAsync();

            //return companysRecords;


            //Find data using AutoMapper

            var companysRecords = await _context.Company.ToListAsync();
            return _mapper.Map<List<CompanyModel>>(companysRecords);
        }

        //Get By Id - API
        public async Task<CompanyModel> GetCompanyByIdAsync(int companyId)
        {
            // One way to find data
            //var company = await _context.Company.Where(x=> x.Id == companyId).Select(x=> new CompanyModel()
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Address = x.Address,
            //    Email = x.Email,
            //    Mobile = x.Mobile,
            //}).FirstOrDefaultAsync();

            //return company;

            //Find data using AutoMapper

            var company = await _context.Company.FindAsync(companyId);
            return _mapper.Map<CompanyModel>(company);
             
        }

        //Add - API
        public async Task<int> AddCompanyAsync(CompanyModel companyModel)
        {
            // one way to update
            //var company = new Company
            //{
            //    Name = companyModel.Name,
            //    Address = companyModel.Address,
            //    Email = companyModel.Email,
            //    Mobile = companyModel.Mobile,
            //};
            //_context.Company.Add(company);
            // await _context.SaveChangesAsync();
            // return company.Id;

            //using AutoMapper

            var company = _mapper.Map<Company>(companyModel);
            _context.Company.Add(company);
            await _context.SaveChangesAsync();
            return company.Id;
        }

        //Update - API
        public async Task UpdateCompanyAsync(int companyId, CompanyModel companyModel)
        {
            // Create Update object one way

            //var company = await _context.Company.FindAsync(companyId);
            //if(company != null)
            //{
            //    company.Name = companyModel.Name;
            //    company.Address = companyModel.Address;
            //    company.Email = companyModel.Email;
            //    company.Mobile = companyModel.Mobile;

            //   await _context.SaveChangesAsync();
            //}

            // Update object another way
            //var company = new Company()
            //{
            //    Id = companyId,
            //    Name = companyModel.Name,
            //    Address = companyModel.Address,
            //    Email = companyModel.Email,
            //    Mobile = companyModel.Mobile,
            //};
            //_context.Company.Update(company);
            //await _context.SaveChangesAsync();


            //Using AutoMapper

            var company = _mapper.Map<CompanyModel, Company>(companyModel);
            company.Id = companyId; // Assuming companyId is already defined
            _context.Company.Update(company);
            await _context.SaveChangesAsync();


        }

        //Update Company Using Patch
        public async Task UpdateCompanyByAsyncPartial(int companyId, JsonPatchDocument companyModal)
        {
            var company = await _context.Company.FindAsync(companyId);
            if(company != null)
            {
                companyModal.ApplyTo(company);
                await _context.SaveChangesAsync();
            }
        }

       //Delete API
        public async Task<bool> DeleteCompanyByIdAsync(int companyId)
        {
            var company = await _context.Company.FindAsync(companyId);

            if (company == null)
            {
                // Company not found, return false or throw an exception
                return false;
            }

            _context.Company.Remove(company);

            await _context.SaveChangesAsync();

            return true;
        }

    }
}
