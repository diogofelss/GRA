using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Textor.GRA.Application.Services.Interfaces;
using Textor.GRA.Application.ViewModels;
using Textor.GRA.Domain.Framework.Extensions;
using Textor.GRA.Domain.Repositories;

namespace Textor.GRA.Application.Services
{
    public class ProducerApplicationService : IProducerApplicationService
    {
        private readonly IProducerReadRepository ProducerReadRepository;

        public ProducerApplicationService(IProducerReadRepository producerReadRepository)
        {
            ProducerReadRepository = producerReadRepository;
        }

        public ProducerWinnerTimeResponseViewModel GetInterval()
        {
            var responseMinNoFilter = new List<ProducerWinnerTimeItemResponseViewModel>();
            var responseMaxNoFilter = new List<ProducerWinnerTimeItemResponseViewModel>();
            var minInterval = int.MaxValue;
            var maxInterval = 0;

            var result = ProducerReadRepository.Get().Include(c => c.Movies).ThenInclude(c => c.Movie).ToList();

            var group = result.GroupBy(c => c.Name).ToList();

            foreach (var list in group)
            {
                var years = list.Select(c => c.Movies.Select(c => c.Movie.Year).First()).ToArray();

                var min = years.minInterval();
                var max = years.maxInterval();

                if (min?.Interval < minInterval)
                {
                    if (min.Interval > 0)
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
    }
}
