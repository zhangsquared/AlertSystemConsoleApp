using AlertSystemConsoleApp.Interface;

namespace AlertSystemConsoleApp.Model
{
    public class Client : IClient
    {
        public string Name { get; }

        public Client(string clientName)
        {
            Name = clientName;
        }

        public void GetInitAlert(IAnalyst analyst, double price)
        {
            string msg = $"alert {Name}: {analyst} {price} initiate";
            CommandUtil.PrintLine(msg);
        }

        public void GetChangeAlert(IAnalyst analyst, double price, StatisticType type, double pct)
        {
            string msg = $"alert {Name}: {analyst} {price} change {type} {pct}";
            CommandUtil.PrintLine(msg);
        }

        public void GetCOutlierAlert(IAnalyst analyst, double price, int num)
        {
            string msg = $"alert {Name}: {analyst} {price} ortlier {num}";
            CommandUtil.PrintLine(msg);
        }

        public override string ToString()
        {
            return Name;
        }

        public bool Equals(IClient other)
        {
            return Name == other.Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
