using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FooBarConsole.Interfaces;

namespace FooBarConsole
{
    /// <summary>
    /// A generic FooBar comparer to check for equality using type, name and alternative name
    /// </summary>
    public class FooBarGenericComparer : IFooBarComparer
    {
        public bool Equals(FooBar x, FooBar y)
        {
            if (x == null || y == null)
            {
                return false;
            }

            if (x.Name == null || y.Name == null)
            {
                return false;
            }

            return x.Type == y.Type &&
                (x.Name.ToLower() == y.Name.ToLower() || HasEqualAlternativeNames(x, y));
        }

        private bool HasEqualAlternativeNames(FooBar x, FooBar y)
        {
            var hasFirst = false;
            var hasSecond = false;

            if (y.AlternativeNames != null && y.AlternativeNames.Count != 0)
            {
                hasFirst = y.AlternativeNames.Contains(x.Name.ToLower());
            }

            if (x.AlternativeNames != null && x.AlternativeNames.Count != 0)
            {
                hasSecond = x.AlternativeNames.Contains(y.Name.ToLower());
            }

            return hasFirst || hasSecond;
        }

        public int GetHashCode(FooBar obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
