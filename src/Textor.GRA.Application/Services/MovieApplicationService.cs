using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Textor.GRA.Application.DTOs;
using Textor.GRA.Application.Services.Base;
using Textor.GRA.Application.Services.Interfaces;
using Textor.GRA.Application.ViewModels;
using Textor.GRA.Domain.Entities;
using Textor.GRA.Domain.Framework.Extensions;
using Textor.GRA.Domain.Framework.Response;
using Textor.GRA.Domain.Framework.Response.Enums;
using Textor.GRA.Domain.Repositories;
using Textor.GRA.Domain.Services.Interfaces;

namespace Textor.GRA.Application.Services
{
    public class MovieApplicationService : ApplicationService, IMovieApplicationService
    {
        private readonly IProducerService ProducerService;
        private readonly IStudioService StudioService;
        private readonly IMovieService MovieService;
        private readonly IProducerReadRepository ProducerReadRepository;
        private readonly IStudioReadRepository StudioReadRepository;
        private readonly IMovieReadRepository MovieReadRepository;
        private readonly IMapper Mapper;

        public MovieApplicationService(IProducerService producerService, IStudioService studioService, IMovieService movieService, IProducerReadRepository producerReadRepository, IStudioReadRepository studioReadRepository, IMovieReadRepository movieReadRepository, IMapper mapper)
        {
            ProducerService = producerService;
            StudioService = studioService;
            MovieService = movieService;
            ProducerReadRepository = producerReadRepository;
            StudioReadRepository = studioReadRepository;
            MovieReadRepository = movieReadRepository;
            Mapper = mapper;
        }

        public MovieResponseViewModel Get()
        {
            var result = MovieReadRepository.Get();

            return Mapper.ProjectTo<MovieResponseViewModel>(result).FirstOrDefault();
        }

        public IList<MovieResponseViewModel> GetAll()
        {
            var result = MovieReadRepository.Get();

            return Mapper.ProjectTo<MovieResponseViewModel>(result).ToList();
        }

        public ProducerWinnerTimeResponseViewModel GetWinnerTime()
        {
            var responseMinNoFilter = new List<ProducerWinnerTimeItemResponseViewModel>();
            var responseMaxNoFilter = new List<ProducerWinnerTimeItemResponseViewModel>();
            var minInterval = int.MaxValue;
            var maxInterval = 0;

            var result = ProducerReadRepository.Get().Include(c => c.Movies).ThenInclude(c => c.Movie).ToList();

            var group = result.GroupBy(c => c.Name).ToList();

            foreach (var list in group)
            {
                var years = list.Select(c => c.Movies.Select(c=> c.Movie.Year).First()).ToArray();

                var min = years.minInterval();
                var max = years.maxInterval();

                if (min?.Interval < minInterval)
                {
                    minInterval = min.Interval;

                    responseMinNoFilter.Add(new ProducerWinnerTimeItemResponseViewModel
                    {
                        Producer = list.Key,
                        Interval = min.Interval,
                        PreviousWin = min.MinYear,
                        FollowingWin = min.MaxYear
                    });
                }
                if (max?.Interval > maxInterval)
                {
                    maxInterval = max.Interval;

                    responseMaxNoFilter.Add(new ProducerWinnerTimeItemResponseViewModel
                    {
                        Producer = list.Key,
                        Interval = max.Interval,
                        PreviousWin = max.MinYear,
                        FollowingWin = max.MaxYear
                    });
                }
            }

            var testes = new ProducerWinnerTimeResponseViewModel();
            testes.Min.AddRange(responseMinNoFilter.Where(c => c.Interval == minInterval).ToList());
            testes.Max.AddRange(responseMaxNoFilter.Where(c => c.Interval == maxInterval).ToList());

            return testes;
        }

        public async Task<Response> Import(IList<CsvDTO> csv)
        {
            var producers = new List<Producer>();
            var studios = new List<Studio>();
            var movies = new List<Movie>();

            foreach (var line in csv)
            {
                var producers1 = line.Producers.Replace("and", ",");
                var producers2 = producers1.Split(',');

                var movie1 = new Movie()
                {
                    Title = line.Title,
                    Year = line.Year,
                    Winner = line.Winner ?? false
                };

                foreach (var column in producers2)
                {
                    var nome = column.TrimEnd().TrimStart();

                    if (ProducerReadRepository.Get(c => c.Name == nome).Any())
                    {
                        movie1.AddProducer(ProducerReadRepository.Get(c => c.Name == nome)
                            .Select(c => c.ID).First());
                    }
                    else
                    {
                        var producer = new Producer
                        {
                            Name = nome
                        };

                        movie1.AddProducer(producer.ID);
                        producers.Add(producer);
                    }
                }

                var studios1 = line.Studios.Split(',');

                foreach (var column in studios1)
                {
                    var nome = column.TrimEnd().TrimStart();

                    if (StudioReadRepository.Get(c => c.Name == nome).Any())
                    {
                        movie1.AddStudio(StudioReadRepository.Get(c => c.Name == nome)
                            .Select(c => c.ID).First());
                    }
                    else
                    {
                        var studio = new Studio
                        {
                            Name = nome
                        };

                        movie1.AddStudio(studio.ID);
                        studios.Add(studio);
                    }
                }

                movies.Add(movie1);
            }

            var testeProducer = await ProducerService.AddRange(producers);
            var testeStudio = await StudioService.AddRange(studios);
            var testeMovies = await MovieService.AddRange(movies);

            return new Response
            {
                Message = "",
                Result = EResult.Success
            };
        }
    }
}
