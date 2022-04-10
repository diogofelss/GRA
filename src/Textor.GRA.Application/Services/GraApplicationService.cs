using AutoMapper;
using System.Collections.Generic;
using Textor.GRA.Application.DTOs;
using Textor.GRA.Application.Services.Base;
using Textor.GRA.Application.Services.Interfaces;
using Textor.GRA.Domain.Repositories;
using Textor.GRA.Domain.Services.Interfaces;

namespace Textor.GRA.Application.Services
{
    public class GraApplicationService : ApplicationService<IMovieService, IMovieReadRepository>, IGraApplicationService
    {
        private readonly IMapper _mapper;

        public GraApplicationService(IMovieService domainService, IMovieReadRepository repository, IMapper mapper) : base(domainService, repository)
        {
            _mapper = mapper;
        }

        public IList<MovieResponseDTO> GetAll()
        {
            //var result = Repository.GetAll();

            //var movieList = _mapper.Map<IList<MovieResponseDTO>>(result);

            //return movieList;

            return new List<MovieResponseDTO>();
        }
    }
}
