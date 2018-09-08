using System;
using System.Collections.Generic;
using System.Text;
using FooBarConsole.Models;

namespace FooBarConsole.Interfaces
{
    public interface IFooBarComparer : IEqualityComparer<FooBar>
    {
        bool Equals(List<FooBar> f1, List<FooBar> f2);
    }
}
