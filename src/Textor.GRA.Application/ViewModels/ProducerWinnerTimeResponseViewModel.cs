using System.Collections.Generic;

namespace Textor.GRA.Application.ViewModels
{
    public class ProducerWinnerTimeResponseViewModel
    {
        public ProducerWinnerTimeResponseViewModel()
        {
            Min = new List<ProducerWinnerTimeItemResponseViewModel>();
            Max = new List<ProducerWinnerTimeItemResponseViewModel>();
        }

        public IList<ProducerWinnerTimeItemResponseViewModel> Min { get; set; }
        public IList<ProducerWinnerTimeItemResponseViewModel> Max { get; set; }
    }

    public class ProducerWinnerTimeItemResponseViewModel
    {
        public string Producer { get; set; }
        public int Interval { get; set; }
        public int PreviousWin { get; set; }
        public int FollowingWin { get; set; }
    }
}
