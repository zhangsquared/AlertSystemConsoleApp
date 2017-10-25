using AlertSystemConsoleApp.Interface;
using System;

namespace AlertSystemConsoleApp.Model
{
    public class DataPoint : IDataPoint
    {
        public IAnalyst Analyst { get; }

        public double Price { get; }

        public DataPoint(IAnalyst analyst, double price)
        {
            Analyst = analyst;
            Price = price;
        }

        public static DataPoint Create(string[] subs)
        {
            DataPoint point = new DataPoint(new Analyst(subs[1]), Convert.ToDouble(subs[2]));
            return point;
        }

        private const double EPSILON = 0.0001;
        public int CompareTo(IDataPoint y)
        {
            if (Math.Abs(Price - y.Price) < EPSILON) return 0;
            if (Price < y.Price) return -1;
            return 1;
        }
    }
}
