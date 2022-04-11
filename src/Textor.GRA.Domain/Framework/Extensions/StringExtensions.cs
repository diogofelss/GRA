﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Textor.GRA.Domain.Framework.Extensions
{
    public static class StringExtensions
    {
        public static int ToInt32(this string souce)
        {
            if (string.IsNullOrWhiteSpace(souce))
                return 0;

            _ = int.TryParse(souce, out int integer);

            return integer;
        }
    }
}
