using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FooBarConsole.Interfaces;
using FooBarConsole.Models;

namespace FooBarConsole
{
    /// <summary>
    /// A generic FooBar comparer to check for equality using type, name and alternative name
    /// </summary>
    public class FooBarTypeNameComparer : IFooBarComparer
    {
        public bool Equals(List<FooBar> f1, List<FooBar> f2)
        {
            if (f1 == null || f2 == null) 
            {
                return false;
            }

            if (f1.Count != f2.Count) 
            {
                return false;
            }

            for (int index = 0; index < f1.Count; index++) 
            {
                var isEqual = Equals(f1[index], f2[index]);

                if (!isEqual) 
                {
                    return false;
                }
            }

            return true;
        }

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
