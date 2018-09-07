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
            var f1 = new FooBar()
            {
                Name = "f1",
                Type = FizzType.Foo,
                AlternativeNames = new List<string>() { "f2" }
            };

            var f2 = new FooBar()
            {
                Name = "f2",
                Type = FizzType.Foo
            };

            var comparer = new FooBarGenericComparer();
            var isEqual = comparer.Equals(f1, f2);

            Console.WriteLine(isEqual);
            Console.ReadLine();
        }
    }
}
