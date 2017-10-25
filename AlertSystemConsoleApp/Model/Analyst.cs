using AlertSystemConsoleApp.Interface;

namespace AlertSystemConsoleApp.Model
{
    public class Analyst : IAnalyst
    {
        public string Name { get; }

        public Analyst(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public bool Equals(IAnalyst other)
        {
           return Name == other.Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
