using AlertSystemConsoleApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlertSystemConsoleApp.Model
{
    public class DataPointCollection : IDataPointCollection
    {
        public List<IDataPoint> list = new List<IDataPoint>();
        private double min = double.MaxValue;
        private double max = double.MinValue;
        private double sum = 0;
        private double squaredSum = 0;

        private int Count => list.Count;

        public void Add(IDataPoint point)
        {
            list.Add(point);

            min = Math.Min(min, point.Price);
            max = Math.Max(max, point.Price);
            sum += point.Price;
            squaredSum += (point.Price * point.Price);
        }

        public CollectionStats GetStats()
        {
            if (!list.Any()) return null;
            return new CollectionStats(GetMean(), GetMedian(), GetMax(), GetMin(), GetStd());
        }

        private double GetMax()
        {
            return max;
        }

        private double GetMean()
        {
            return sum / Count;
        }

        private double GetMedian()
        {
            list.Sort(); // can be improved
            return list[Count / 2].Price;
        }

        private double GetMin()
        {
            return min;
        }

        private double GetStd()
        {
            double mean = GetMean();
            double variance = squaredSum - mean * mean;
            return Math.Sqrt(variance);
        }
    }
}
