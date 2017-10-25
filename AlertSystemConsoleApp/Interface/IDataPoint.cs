using System;

namespace AlertSystemConsoleApp.Interface
{
    public interface IDataPoint : IComparable<IDataPoint>
    {
        IAnalyst Analyst { get; }
        double Price { get; }
    }
}
