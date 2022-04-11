﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Textor.GRA.Application.ViewModels
{
    public class ProducerWinnerTimeResponseViewModel
    {
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
