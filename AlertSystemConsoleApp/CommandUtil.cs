using AlertSystemConsoleApp.Interface;
using AlertSystemConsoleApp.Model;
using System;

namespace AlertSystemConsoleApp
{
    public static class CommandUtil
    {
        public static void ReadString(string input, IAlertSystem system)
        {
            string[] subs = input.Split(' ');

            if(subs[0].Equals("point")) // point <analylstName> <priceEstimate>
            {
                DataPoint point = DataPoint.Create(subs);
                system.AddDataPoint(point);
            }
            else if(subs[0].Equals("subscribe"))
            {
                if(subs.Length == 3) // subscribe <clientName> initiate
                {
                    Client client = new Client(subs[1]);
                    system.Attach(client);
                }
                else if(subs.Length == 5) // subscribe <clientName> change <stat> <pct>
                {
                    ChangeRule rule = ChangeRule.Create(subs);
                    system.Attach(rule);
                }
                else if(subs.Length == 4) // subscribe <clientName> outlier <stat>
                {
                    OutlierRule rule = OutlierRule.Create(subs);
                    system.Attach(rule);
                }
            }
            else if(subs[0].Equals("unsubscribe"))
            {
                Client client = new Client(subs[1]);
                system.Detach(client);
            }
            else
            {
                throw new InvalidOperationException("Cannot parse the command");
            }
        }

        public static void PrintLine(string str)
        {
            Console.WriteLine(str);
        }
    }
}
