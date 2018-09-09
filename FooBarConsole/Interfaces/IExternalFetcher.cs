using System;
using System.Collections.Generic;
using System.Text;
using FooBarConsole.Models;

namespace FooBarConsole.Interfaces
{
    /// <summary>
    /// Interface of external FooBar fetcher
    /// </summary>
    public interface IExternalFetcher
    {
        List<FooBar> GetExternalFooBar();
    }
}
