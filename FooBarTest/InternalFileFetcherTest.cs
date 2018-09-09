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
    public class InternalFileFetcherTest
    {
        private readonly Mock<IConfigurationReader> _config;
        private readonly InternalFileFetcher _fetcher;

        public InternalFileFetcherTest()
        {
            var factory = new MockRepository(MockBehavior.Loose);
            _config = factory.Create<IConfigurationReader>();
            _fetcher = new InternalFileFetcher(_config.Object);
        }

        [Fact]
        public void List_Parse_Valid()
        {
            _config.Setup(_ => _.GetInternalFile()).Returns("InternalFooBar.json");

            var foos = _fetcher.GetInternalFooBar();

            Assert.True(foos.Count > 0);
        }
    }
}