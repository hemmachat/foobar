﻿using System;
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
    public class TypeNameComparer : IComparer
    {
        /// <summary>
        /// Check two lists of FooBar if they are equal in type, name or alternative name
        /// </summary>
        /// <param name="f1">First FooBar</param>
        /// <param name="f2">Second FooBar</param>
        /// <returns>True if they are equal</returns>
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

        /// <summary>
        /// Compare two FooBars if they are equal
        /// </summary>
        /// <param name="x">First FooBar</param>
        /// <param name="y">Second FooBar</param>
        /// <returns>True if they are equal</returns>
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
                (x.Name.Equals(y.Name, StringComparison.OrdinalIgnoreCase) || HasEqualAlternativeNames(x, y));
        }

        /// <summary>
        /// Check for an equal alternative names
        /// </summary>
        /// <param name="x">First FooBar</param>
        /// <param name="y">Second FooBar</param>
        /// <returns>True if there is a match name</returns>
        private bool HasEqualAlternativeNames(FooBar x, FooBar y)
        {
            var hasFirst = false;
            var hasSecond = false;

            if (y.AlternativeNames != null && y.AlternativeNames.Count != 0)
            {
                hasFirst = y.AlternativeNames.Contains(x.Name, StringComparer.OrdinalIgnoreCase);
            }

            if (x.AlternativeNames != null && x.AlternativeNames.Count != 0)
            {
                hasSecond = x.AlternativeNames.Contains(y.Name, StringComparer.OrdinalIgnoreCase);
            }

            return hasFirst || hasSecond;
        }

        public int GetHashCode(FooBar obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
