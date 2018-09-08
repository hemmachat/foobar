using System.Collections.Generic;
using FooBarConsole.Models;

namespace FooBarConsole.Interfaces
{
    public interface IFooBarInternalFetcher
    {
         List<FooBar> GetInternalFooBar();
    }
}