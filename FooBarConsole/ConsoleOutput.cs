﻿using FooBarConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FooBarConsole
{
    public class ConsoleOutput : IConsoleOutput
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}