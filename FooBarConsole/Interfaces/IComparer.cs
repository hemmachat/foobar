using System;
using System.Collections.Generic;
using System.Text;
using FooBarConsole.Models;

namespace FooBarConsole.Interfaces
{
    /// <summary>
    /// Interface to check if two lists of FooBars are equal
    /// </summary>
    /// <typeparam name="FooBar">FooBar class to compare</typeparam>
    public interface IComparer : IEqualityComparer<FooBar>
    {
        bool Equals(List<FooBar> f1, List<FooBar> f2);
    }
}
