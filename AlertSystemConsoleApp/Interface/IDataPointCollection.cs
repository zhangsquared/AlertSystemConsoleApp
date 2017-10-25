namespace AlertSystemConsoleApp.Interface
{
    public interface IDataPointCollection
    {
        void Add(IDataPoint point);

        CollectionStats GetStats();
    }

    public class CollectionStats
    {
        public double Mean { get; }
        public double Median { get; }
        public double Max { get; }
        public double Min { get; }
        public double Std { get; }

        public CollectionStats(double mean, double median, double max, double min, double std)
        {
            Mean = mean;
            Median = median;
            Max = max;
            Min = min;
            Std = std;
        }
    }
}
