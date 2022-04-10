using AutoMapper;
using Textor.GRA.Application.DTOs;
using Textor.GRA.Domain.Entities;

namespace Textor.GRA.Application.Automapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            ConfigureDomainToApplication();
        }

        public void ConfigureDomainToApplication()
        {
            CreateMap<Movie, MovieResponseDTO>()
                .ForMember(c => c.Title, opts => opts.MapFrom(p => p.Title))
                .ForMember(c => c.Year, opts => opts.MapFrom(p => p.Year));
        }
    }
}
