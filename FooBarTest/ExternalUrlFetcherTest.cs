using System;
using Xunit;
using Moq;
using FooBarConsole.Models;
using System.Collections.Generic;
using FooBarConsole.Interfaces;
using System.Collections;
using FooBarConsole;
using System.Configuration;

namespace FooBarTest
{
    public class ExternalUrlFetcherTest
    {
        private readonly Mock<IConfigurationReader> _config;
        private readonly ExternalUrlFetcher _fetcher;

        public ExternalUrlFetcherTest()
        {
            var factory = new MockRepository(MockBehavior.Loose);
            _config = factory.Create<IConfigurationReader>();
            _fetcher = new ExternalUrlFetcher(_config.Object);
        }

        [Fact]
        public void List_Parse_Valid()
        {
            _config.Setup(_ => _.GetExternalUrl()).Returns("https://raw.githubusercontent.com/hemmachat/foobar/master/FooBarConsole/TestFooBar/ExternalFooBar.json");

            var foos = _fetcher.GetExternalFooBar();

            Assert.True(foos.Count > 0);
        }
    }
}