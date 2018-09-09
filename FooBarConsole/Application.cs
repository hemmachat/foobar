using System;
using System.Collections.Generic;
using FooBarConsole.Interfaces;
using FooBarConsole.Models;

namespace FooBarConsole
{
    public class Application : IApplication
    {
        private readonly IOutput _output;
        private readonly IInternalFetcher _internalFetcher;
        private readonly IExternalFetcher _externalFetcher;
        private readonly IComparer _comparer;

        public Application(IOutput output, IInternalFetcher internalFetcher, IExternalFetcher externalFetcher, IComparer comparer)
        {
            _output = output;
            _internalFetcher = internalFetcher;
            _externalFetcher = externalFetcher;
            _comparer = comparer;
        }

        public void Run()
        {
            // compare lists of internal and external FooBar
            var internalFooBars = _internalFetcher.GetInternalFooBar();
            var externalFooBars = _externalFetcher.GetExternalFooBar();
            var listEqual = _comparer.Equals(internalFooBars, externalFooBars);
            _output.ShowMessage(listEqual.ToString());

            // compare individual FooBar
            var f1 = new FooBar()
            {
                Name = "f1",
                AlternativeNames = new List<string>() { "fff4", "f2" }
            };
            var f2 = new FooBar()
            {
                Name = "f2",
                Type = FizzType.Foo
            };
            var isEqual = _comparer.Equals(f1, f2);
            _output.ShowMessage(isEqual.ToString());
        }
    }
}