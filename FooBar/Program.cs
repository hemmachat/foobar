using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace FooBar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HEllo");
            Console.ReadLine();

            List<FooBar> externals = new List<FooBar>();
            List<FooBar> internals = new List<FooBar>();

            var f1 = new FooBar()
            {
                Name = "f1",
                Type = FizzType.Five
            };

            var f2 = new FooBar()
            {
                Name = "f2",
                Type = FizzType.Foo
            };

            var comparer = new FooBarGenericComparer();
            var isEqual = comparer.Equals(f1, f2);

        }
    }
}
