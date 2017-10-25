using AlertSystemConsoleApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlertSystemConsoleApp.Model
{
    public class AlertSystem : IAlertSystem
    {
        private IDataPointCollection dataPoints;
        private ISet<IAnalyst> analysts;
        private ISet<IClient> clients;
        private IList<IRule> rules;

        public AlertSystem()
        {
            dataPoints = new DataPointCollection();
            analysts = new HashSet<IAnalyst>();
            clients = new HashSet<IClient>();
            rules = new List<IRule>();
        }

        public void AddDataPoint(IDataPoint dataPoint)
        {
            CollectionStats orig = dataPoints.GetStats();
            dataPoints.Add(dataPoint);
            CollectionStats updated = dataPoints.GetStats();

            // alert new analyst
            if (!analysts.Contains(dataPoint.Analyst))
            {
                analysts.Add(dataPoint.Analyst);
                foreach(IClient client in clients)
                {
                    client.GetInitAlert(dataPoint.Analyst, dataPoint.Price);
                }
            } 

            // alert changes and outliers
            foreach(IRule rule in rules)
            {
                if(rule.IsTriggered(orig, updated, dataPoint, out double pct))
                {
                    rule.Trigger(dataPoint.Analyst, dataPoint.Price, pct); 
                }
            }
        }

        public void Attach(IClient client)
        {
            clients.Add(client);
        }
        public void Detach(IClient client)
        {
            IClient c = clients.First(x => x.GetHashCode() == client.GetHashCode());
            clients.Remove(c);

            IList<IRule> toBeRemoved = rules.Where(x => x.Client.GetHashCode() == client.GetHashCode()).ToList();
            foreach (IRule rule in toBeRemoved) rules.Remove(rule);
        }

        public void Attach(IRule rule)
        {
            rules.Add(rule);
        }
        public void Detach(IRule rule)
        {
            throw new NotImplementedException();
        }
    }
}
