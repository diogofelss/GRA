using AutoMapper;
using Textor.GRA.Application.ViewModels;
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
            CreateMap<MovieProducer, MovieProducerResponseViewModel>()
                .ForMember(c => c.Name, opts => opts.MapFrom(p => p.Producer.Name));

            CreateMap<MovieStudio, MovieStudioResponseViewModel>()
                .ForMember(c => c.Name, opts => opts.MapFrom(p => p.Studio.Name));

            CreateMap<Movie, MovieResponseViewModel>()
                .ForMember(c => c.Title, opts => opts.MapFrom(p => p.Title))
                .ForMember(c => c.Year, opts => opts.MapFrom(p => p.Year))
                .ForMember(c => c.Producers, opts => opts.MapFrom(p => p.Producers))
                .ForMember(c => c.Studios, opts => opts.MapFrom(p => p.Studios));
        }
    }
}
