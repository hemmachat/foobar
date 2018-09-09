﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Autofac;
using FooBarConsole.Interfaces;
using FooBarConsole.Models;
using System.Linq;

namespace FooBarConsole
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {   
            var builder = new ContainerBuilder();
            builder.RegisterType<TypeNameComparer>().As<Interfaces.IComparer>();
            builder.RegisterType<ConfigurationReader>().As<IConfigurationReader>();
            builder.RegisterType<InternalFileFetcher>().As<IInternalFetcher>();
            builder.RegisterType<ExternalUrlFetcher>().As<IExternalFetcher>();
            builder.RegisterType<ConsoleOutput>().As<IOutput>();
            Container = builder.Build();

            using (var scope = Container.BeginLifetimeScope())
            {
                var internalFetcher = scope.Resolve<IInternalFetcher>();
                var externalFetcher = scope.Resolve<IExternalFetcher>();
                var comparer = scope.Resolve<Interfaces.IComparer>();
                var output = scope.Resolve<IOutput>();

                var internalFooBars = internalFetcher.GetInternalFooBar();
                var externalFooBars = externalFetcher.GetExternalFooBar();

                var first = comparer.Equals(internalFooBars, externalFooBars);
                output.ShowMessage(first.ToString());

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
