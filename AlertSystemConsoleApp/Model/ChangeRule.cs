using AlertSystemConsoleApp.Interface;
using System;

namespace AlertSystemConsoleApp.Model
{
    public class ChangeRule : IChangeRule
    {
        public ChangeRule(IClient client, StatisticType stat, double threshold)
        {
            Client = client;
            SType = stat;
            Threshold = threshold;
        }

        public IClient Client { get; }

        public StatisticType SType { get; }

        public double Threshold { get; }


        public bool IsTriggered(CollectionStats orig, CollectionStats updated, IDataPoint added, out double percentage)
        {
            if (orig == null)
            {
                percentage = 0;
                return false;
            }

            switch(SType)
            {
                case StatisticType.Mean:
                    percentage = updated.Mean - orig.Mean;
                    return percentage > Threshold;
                case StatisticType.Max:
                    percentage = updated.Max - orig.Max;
                    return percentage > Threshold;
                case StatisticType.Min:
                    percentage = updated.Min - orig.Min;
                    return percentage > Threshold;
                case StatisticType.Std:
                    percentage = updated.Std - orig.Std;
                    return percentage > Threshold;
                case StatisticType.Median:
                    percentage = updated.Median - orig.Median;
                    return percentage > Threshold;
                default:
                    throw new InvalidOperationException("Dont know what type");
            }
        }

        public static ChangeRule Create(string[] subs)
        {
            Client c = new Client(subs[1]);
            StatisticType type = StatisticType.Max;
            if (subs[3].Equals("max", StringComparison.InvariantCultureIgnoreCase))
            {
                type = StatisticType.Max;
            }
            else if (subs[3].Equals("min", StringComparison.InvariantCultureIgnoreCase))
            {
                type = StatisticType.Min;
            }
            else if (subs[3].Equals("std", StringComparison.InvariantCultureIgnoreCase))
            {
                type = StatisticType.Std;
            }
            else if (subs[3].Equals("median", StringComparison.InvariantCultureIgnoreCase))
            {
                type = StatisticType.Median;
            }
            else if (subs[3].Equals("mean", StringComparison.InvariantCultureIgnoreCase))
            {
                type = StatisticType.Mean;
            }
            else
            {
                throw new InvalidOperationException("dont know the type");
            }

            ChangeRule r = new ChangeRule(c, type, Convert.ToDouble(subs[4]));
            return r;
        }

        public void Trigger(IAnalyst analyst, double price, double pct)
        {
            Client.GetChangeAlert(analyst, price, SType, pct);
        }
    }
}
