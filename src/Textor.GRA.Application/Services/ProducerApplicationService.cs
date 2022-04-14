using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Textor.GRA.Application.Services.Interfaces;
using Textor.GRA.Application.ViewModels;
using Textor.GRA.Domain.Framework.Extensions;
using Textor.GRA.Domain.Repositories;

namespace Textor.GRA.Application.Services
{
    public class ProducerApplicationService : IProducerApplicationService
    {
        private readonly IProducerReadRepository ProducerReadRepository;
        private readonly IMovieReadRepository MovieReadRepository;

        public ProducerApplicationService(IProducerReadRepository producerReadRepository, IMovieReadRepository movieReadRepository)
        {
            ProducerReadRepository = producerReadRepository;
            MovieReadRepository = movieReadRepository;
        }

        public ProducerWinnerTimeResponseViewModel GetInterval()
        {
            var responseMinNoFilter = new List<ProducerWinnerTimeItemResponseViewModel>();
            var responseMaxNoFilter = new List<ProducerWinnerTimeItemResponseViewModel>();
            var minInterval = int.MaxValue;
            var maxInterval = 0;

            var list = ProducerReadRepository.GetInterval().ToList();

            var group = list.GroupBy(c => c.ID);

            foreach (var item in group)
            {
                var years = ProducerReadRepository.GetMovieProducers()
                    .Where(c => c.ProducerID == item.Key && c.Movie.Winner)
                    .Select(c => c.Movie.Year).ToList();

                var min = years.MinInterval();
                var max = years.MaxInterval();

                if (min?.Interval < minInterval)
                {
                    if (min.Interval > 0)
                        minInterval = min.Interval;

                    responseMinNoFilter.Add(new ProducerWinnerTimeItemResponseViewModel
                    {
                        Producer = item.Select(c => c.Name).First(),
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
                        Producer = item.Select(c => c.Name).First(),
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
    }
}
