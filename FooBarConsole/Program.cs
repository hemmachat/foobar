using System;
using Autofac;
using FooBarConsole.Interfaces;
using FooBarConsole.Models;

namespace FooBarConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ConfigureContainer();
            
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }            
        }

        /// <summary>
        /// Configure all necessary classes for the application
        /// </summary>
        /// <returns></returns>
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TypeNameComparer>().As<Interfaces.IComparer>();
            builder.RegisterType<ConfigurationReader>().As<IConfigurationReader>();
            builder.RegisterType<FileReader>().As<IFileReader>();
            builder.RegisterType<UrlReader>().As<IFileReader>();            
            builder.RegisterType<InternalFileFetcher>().As<IInternalFetcher>();
            builder.RegisterType<ExternalUrlFetcher>().As<IExternalFetcher>();
            builder.RegisterType<ConsoleOutput>().As<IOutput>();
            builder.RegisterType<Application>().As<IApplication>();

            return builder.Build();
        }
    }
}
