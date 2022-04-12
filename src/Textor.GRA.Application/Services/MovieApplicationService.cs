using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Textor.GRA.Application.Services.Base;
using Textor.GRA.Application.Services.Interfaces;
using Textor.GRA.Application.ViewModels;
using Textor.GRA.Domain.Repositories;

namespace Textor.GRA.Application.Services
{
    public class MovieApplicationService : ApplicationService, IMovieApplicationService
    {
        private readonly IMovieReadRepository MovieReadRepository;
        private readonly IMapper Mapper;

        public MovieApplicationService(IMovieReadRepository movieReadRepository, IMapper mapper)
        {
            MovieReadRepository = movieReadRepository;
            Mapper = mapper;
        }

        public IList<MovieResponseViewModel> GetNominated(int year)
        {
            var result = MovieReadRepository.Get(c => c.Year == year);

            return Mapper.ProjectTo<MovieResponseViewModel>(result).ToList();
        }

        public IList<MovieResponseViewModel> GetNominated()
        {
            var result = MovieReadRepository.Get();

            return Mapper.ProjectTo<MovieResponseViewModel>(result).ToList();
        }

        public IList<MovieResponseViewModel> GetWinners(int year)
        {
            var result = MovieReadRepository.Get(c => c.Year == year && c.Winner);

            return Mapper.ProjectTo<MovieResponseViewModel>(result).ToList();
        }

        public IList<MovieResponseViewModel> GetWinners()
        {
            var result = MovieReadRepository.Get(c => c.Winner);

            return Mapper.ProjectTo<MovieResponseViewModel>(result).ToList();
        }
    }
}
