namespace AlertSystemConsoleApp.Interface
{
    public interface IRule
    {
        IClient Client { get; }

        bool IsTriggered(CollectionStats orig, CollectionStats updated, IDataPoint added, out double percentage);
        void Trigger(IAnalyst analyst, double price, double pct);
    }

    public interface IChangeRule : IRule
    {
        StatisticType SType { get; }
        double Threshold { get; }
    }

    public interface IOutlierRule : IRule
    {
        int Num { get; }
    }

    public enum StatisticType
    {
        Mean,
        Median,
        Max, 
        Min, 
        Std
    }
}
