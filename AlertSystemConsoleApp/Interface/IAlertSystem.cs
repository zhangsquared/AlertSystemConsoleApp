namespace AlertSystemConsoleApp.Interface
{
    public interface IAlertSystem
    {
        void AddDataPoint(IDataPoint dataPoint);

        void Attach(IClient client);
        void Detach(IClient client);

        void Attach(IRule rule);
        void Detach(IRule rule);
    }
}
