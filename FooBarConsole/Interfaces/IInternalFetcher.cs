using System.Collections.Generic;
using FooBarConsole.Models;

namespace FooBarConsole.Interfaces
{
    public interface IInternalFetcher
    {
         List<FooBar> GetInternalFooBar();
    }
}