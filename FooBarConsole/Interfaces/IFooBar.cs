﻿using System;
using System.Collections.Generic;
using System.Text;
using FooBarConsole.Models;

namespace FooBarConsole.Interfaces
{
    public interface IFooBar
    {
        string Name { get; set; }
        List<string> AlternativeNames { get; set; }
        long Id { get; set; }
        FizzType Type { get; set; }
    }
}
