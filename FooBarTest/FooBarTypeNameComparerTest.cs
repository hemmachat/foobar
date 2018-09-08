using System;
using Xunit;
using Moq;
using FooBarConsole.Models;
using System.Collections.Generic;
using FooBarConsole.Interfaces;
using System.Collections;
using FooBarConsole;

namespace FooBarTest
{
    public class FooBarTypeNameComparerTest
    {
        private readonly IFooBarComparer _comparer;

        public FooBarTypeNameComparerTest()
        {
            var factory = new MockRepository(MockBehavior.Loose);
            _comparer = new FooBarTypeNameComparer();         
        }

        [Fact]
        public void Match_Name_Type_Valid()
        {
            var f1 = new FooBar()
            {
                Name = "f1",
                Type = FizzType.Foo
            };

            var f2 = new FooBar()
            {
                Name = "f1",
                Type = FizzType.Foo
            };

            Assert.True(_comparer.Equals(f1, f2));
        }

        [Fact]
        public void Match_Name_Type_Case_Valid()
        {
            var f1 = new FooBar()
            {
                Name = "f1",
                Type = FizzType.Foo
            };

            var f2 = new FooBar()
            {
                Name = "F1",
                Type = FizzType.Foo
            };

            Assert.True(_comparer.Equals(f1, f2));
        }

        [Fact]
        public void Match_Alternative_Names_Valid()
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

            Assert.True(_comparer.Equals(f1, f2));
        }

        [Fact]
        public void Match_Case_Alternative_Names_Valid()
        {
            var f1 = new FooBar()
            {
                Name = "f1",
                Type = FizzType.Foo,
                AlternativeNames = new List<string>() { "F2" }
            };

            var f2 = new FooBar()
            {
                Name = "f2",
                Type = FizzType.Foo
            };

            Assert.True(_comparer.Equals(f1, f2));
        }

        [Fact]
        public void Unmatch_Name_Invalid()
        {
            var f1 = new FooBar()
            {
                Name = "f1",
                Type = FizzType.Five
            };

            var f2 = new FooBar()
            {
                Name = "f2",
                Type = FizzType.Five
            };

            Assert.False(_comparer.Equals(f1, f2));
        }

        [Fact]
        public void Unmatch_Type_Invalid()
        {
            var f1 = new FooBar()
            {
                Name = "f1",
                Type = FizzType.Foo
            };

            var f2 = new FooBar()
            {
                Name = "f1",
                Type = FizzType.Five
            };

            Assert.False(_comparer.Equals(f1, f2));
        }

        [Fact]
        public void Unmatch_Alternative_Names_Invalid()
        {
            var f1 = new FooBar()
            {
                Name = "f1",
                Type = FizzType.Zebra
            };

            var f2 = new FooBar()
            {
                Name = "f2",
                Type = FizzType.Zebra,
                AlternativeNames = new List<string>() { "ff2" }
            };

            Assert.False(_comparer.Equals(f1, f2));
        }
    }
}
