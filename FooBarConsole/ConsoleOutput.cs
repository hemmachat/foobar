using FooBarConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FooBarConsole
{
    /// <summary>
    /// A simple console output
    /// </summary>
    public class ConsoleOutput : IOutput
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
