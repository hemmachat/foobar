using System;
using System.Collections.Generic;
using System.Text;
using FooBarConsole.Models;

namespace FooBarConsole.Interfaces
{
    public interface IExternalFetcher
    {
        List<FooBar> GetExternalFooBar();
    }
}
