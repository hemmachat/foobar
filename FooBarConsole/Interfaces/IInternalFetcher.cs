using System.Collections.Generic;
using FooBarConsole.Models;

namespace FooBarConsole.Interfaces
{
    /// <summary>
    /// Interface of internal FooBar fetcher
    /// </summary>
    public interface IInternalFetcher
    {
         List<FooBar> GetInternalFooBar();
    }
}