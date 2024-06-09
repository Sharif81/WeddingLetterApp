using AutoMapper;
using System.Linq;
using WeddingLetter.Data;
using WeddingLetter.Models;

namespace WeddingLetter.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Company, CompanyModel>().ReverseMap();
            CreateMap<Packages, PackagesModel>().ReverseMap();

            CreateMap<Events, EventsModel>()
                .ForMember(dest => dest.Programs, opt => opt.MapFrom(src => src.Programs.Select(x =>
                    new ProgramsModel()
                    {
                        Id = x.Id,
                        EventId = x.EventId,
                        Date = x.Date,
                        ProgramName = x.ProgramName,
                        Vanue = x.Vanue
                    }
                )));
            CreateMap<EventsModel, Events>();

            CreateMap<Programs, ProgramsModel>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<ProgramsModel, Programs>();

            //CreateMap<Events, EventsModel>().ReverseMap();
            //CreateMap<Programs, ProgramsModel>().ReverseMap();

            CreateMap<Venues, VenueModel>().ReverseMap();

            CreateMap<Payments, PaymentsModel>();
        }
    }
}
