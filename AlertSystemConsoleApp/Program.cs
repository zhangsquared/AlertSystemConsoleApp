using AlertSystemConsoleApp.Interface;
using AlertSystemConsoleApp.Model;
using System;

namespace AlertSystemConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IAlertSystem system = new AlertSystem();
            bool flag = true;
            while(flag)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    flag = false;
                }
                else
                {
                    CommandUtil.ReadString(input, system);
                }
            }
        }
    }
}
