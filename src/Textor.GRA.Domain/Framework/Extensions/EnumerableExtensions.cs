using System;
using System.Collections.Generic;

namespace Textor.GRA.Domain.Framework.Extensions
{
    public class MoviesIntervalDTO
    {
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
        public int Interval { get; set; }
    }

    public static class EnumerableExtensions
    {
        public static void AddRange<T>(this ICollection<T> destination,
                                       IEnumerable<T> source)
        {
            foreach (T item in source)
            {
                destination.Add(item);
            }
        }

        public static MoviesIntervalDTO MinInterval(this int[] source)
        {
            if (source.Length <= 1)
                return null;

            int diff = int.MaxValue;
            var minValue = 0;
            var maxValue = 1;
            var lenght = source.Length;

            Array.Sort(source);

            for (int i = 0; i < lenght - 1; i++)
            {
                if (source[i + 1] - source[i] < diff)
                {
                    diff = source[i + 1] - source[i];
                    minValue = source[i];
                    maxValue = source[i + 1];
                }
            }

            return new MoviesIntervalDTO
            {
                Interval = diff,
                MinYear = minValue,
                MaxYear = maxValue
            };
        }

        public static MoviesIntervalDTO MaxInterval(this int[] source)
        {
            if (source.Length <= 1)
                return null;

            int diff = 0;
            var minValue = 0;
            var maxValue = 1;
            var lenght = source.Length;

            Array.Sort(source);

            for (int i = 0; i < lenght - 1; i++)
            {
                if (source[i + 1] - source[i] > diff)
                {
                    diff = source[i + 1] - source[i];
                    minValue = source[i];
                    maxValue = source[i + 1];
                }
            }

            return new MoviesIntervalDTO
            {
                Interval = diff,
                MinYear = minValue,
                MaxYear = maxValue
            };
        }
    }
}
