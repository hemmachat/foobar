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
        private readonly Mock<IFileReader> _reader;
        private readonly InternalFileFetcher _fetcher;

        public InternalFileFetcherTest()
        {
            var factory = new MockRepository(MockBehavior.Loose);
            _reader = factory.Create<IFileReader>();
            _fetcher = new InternalFileFetcher(_reader.Object);
        }

        [Fact]
        public void List_Parse_Valid()
        {
            var content = @"[
                {
                    'name': 'f1',
                    'id': 1,
                    'type': 'Foo'
                },
                {
                    'name': 'f3',
                    'id': 3,
                    'type': 'Foo',
                    'alternativeNames': ['ff2', 'f2']
                }
                ]";
            _reader.Setup(_ => _.ReadFile()).Returns(content);

            var foos = _fetcher.GetInternalFooBar();

            Assert.True(foos.Count > 0);
        }
    }
}