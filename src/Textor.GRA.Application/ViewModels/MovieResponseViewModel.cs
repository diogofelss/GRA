using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Textor.GRA.Application.ViewModels
{
    public class MovieResponseViewModel
    {
        public string Title { get;set; }
        public int Year { get; set; }
        public bool Winner { get; set; }
        public IList<MovieStudioResponseViewModel> Studios { get; set; }
        public IList<MovieProducerResponseViewModel> Producers { get; set; }
    }

    public class MovieStudioResponseViewModel
    {
        public string Name { get; set; }
    }
    public class MovieProducerResponseViewModel
    {
        public string Name { get; set; }
    }
}
