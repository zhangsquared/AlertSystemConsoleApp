using AlertSystemConsoleApp.Interface;
using System;

namespace AlertSystemConsoleApp.Model
{
    public class OutlierRule : IOutlierRule
    {
        public OutlierRule(IClient client, int num)
        {
            Client = client;
            Num = num;
        }

        public int Num { get; }

        public IClient Client { get; }


        public static OutlierRule Create(string[] subs)
        {
            Client c = new Client(subs[1]);
            OutlierRule r = new OutlierRule(c, Convert.ToInt32(subs[3]));
            return r;
        }

        public bool IsTriggered(CollectionStats orig, CollectionStats updated, IDataPoint added, out double percentage)
        {
            if (orig == null)
            {
                percentage = 0;
                return false;
            }

            percentage = 0;
            return Math.Abs(added.Price - orig.Mean) > Num * orig.Std;
        }

        public void Trigger(IAnalyst analyst, double price, double pct)
        {
            Client.GetCOutlierAlert(analyst, price, Num);
        }
    }
}
