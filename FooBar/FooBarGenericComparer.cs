using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FooBar
{
    /// <summary>
    /// A generic FooBar comparer to check for equality using type, name and alternative name
    /// </summary>
    public class FooBarGenericComparer : IEqualityComparer<FooBar>
    {
        public bool Equals(FooBar x, FooBar y)
        {
            if (x == null || y == null)
            {
                return false;
            }

            return x.Type == y.Type &&
                (x.Name.ToLower() == y.Name.ToLower() ||
                x.AlternativeNames.Contains(y.Name.ToLower()) || 
                y.AlternativeNames.Contains(x.Name.ToLower()));
        }

        public int GetHashCode(FooBar obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
