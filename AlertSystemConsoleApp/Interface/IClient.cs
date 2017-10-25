using System;

namespace AlertSystemConsoleApp.Interface
{
    public interface IClient : IEquatable<IClient>
    {
        string Name { get; }

        void GetInitAlert(IAnalyst analyst, double price);
        void GetChangeAlert(IAnalyst analyst, double price, StatisticType type, double pct);
        void GetCOutlierAlert(IAnalyst analyst, double price, int num);
    }
}
