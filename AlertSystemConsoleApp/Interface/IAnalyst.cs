using System;

namespace AlertSystemConsoleApp.Interface
{
    public interface IAnalyst : IEquatable<IAnalyst>
    {
        string Name { get; }
    }
}
