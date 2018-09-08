using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Autofac;
using FooBarConsole.Interfaces;

namespace FooBarConsole
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {   
            var builder = new ContainerBuilder();
            builder.RegisterType<FooBarGenericComparer>().As<IFooBarComparer>();
            builder.RegisterType<ConsoleOutput>().As<IOutput>();
            Container = builder.Build();

            using (var scope = Container.BeginLifetimeScope())
            {
                var comparer = scope.Resolve<IFooBarComparer>();
                var output = scope.Resolve<IOutput>();

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

                var isEqual = comparer.Equals(f1, f2);
                output.ShowMessage(isEqual.ToString());
                Console.ReadLine();
            }
            
        }
    }
}
