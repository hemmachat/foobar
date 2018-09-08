using System;
using System.Collections.Generic;
using System.Text;
using FooBarConsole.Models;

namespace FooBarConsole.Interfaces
{
    public interface IFooBarExternalFetcher
    {
        List<FooBar> GetExternalFooBar();
    }
}
