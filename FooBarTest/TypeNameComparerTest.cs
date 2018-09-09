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
    public class TypeNameComparerTest
    {
        private readonly FooBarConsole.Interfaces.IComparer _comparer;

        public TypeNameComparerTest()
        {
            var factory = new MockRepository(MockBehavior.Loose);
            _comparer = new TypeNameComparer();         
        }

        [Fact]
        public void List_Match_Name_Type_Valid()
        {
            var f1 = new List<FooBar>() 
            {
                new FooBar() 
                {
                    Name = "f1",
                    Type = FizzType.Foo
                }
            };

            var f2 = new List<FooBar>()
            {
                new FooBar()
                {
                    Name = "f1",
                    Type = FizzType.Foo
                }
            };

            Assert.True(_comparer.Equals(f1, f2));
        }

        [Fact]
        public void List_Match_Case_Name_Type_Valid()
        {
            var f1 = new List<FooBar>() 
            {
                new FooBar() 
                {
                    Name = "F1",
                    Type = FizzType.Foo
                }
            };

            var f2 = new List<FooBar>()
            {
                new FooBar()
                {
                    Name = "f1",
                    Type = FizzType.Foo
                }
            };

            Assert.True(_comparer.Equals(f1, f2));
        }

        [Fact]
        public void List_Match_Name_Type_Alternate_Valid()
        {
            var f1 = new List<FooBar>() 
            {
                new FooBar() 
                {
                    Name = "f1",
                    Type = FizzType.Foo,
                    AlternativeNames = new List<string>() 
                    {
                        "ff1"
                    }
                }
            };

            var f2 = new List<FooBar>()
            {
                new FooBar()
                {
                    Name = "f1",
                    Type = FizzType.Foo,
                    AlternativeNames = new List<string>() 
                    {
                        "ff2"
                    }
                }
            };

            Assert.True(_comparer.Equals(f1, f2));
        }

        [Fact]
        public void List_Match_Name_Type_Same_Alternate_Valid()
        {
            var f1 = new List<FooBar>() 
            {
                new FooBar() 
                {
                    Name = "f2",
                    Type = FizzType.Foo,
                    AlternativeNames = new List<string>() 
                    {
                        "f1"
                    }
                }
            };

            var f2 = new List<FooBar>()
            {
                new FooBar()
                {
                    Name = "f1",
                    Type = FizzType.Foo
                }
            };

            Assert.True(_comparer.Equals(f1, f2));
        }

        [Fact]
        public void List_Match_Name_Type_Same_Cap_Alternate_Valid()
        {
            var f1 = new List<FooBar>() 
            {
                new FooBar() 
                {
                    Name = "f2",
                    Type = FizzType.Foo,
                    AlternativeNames = new List<string>() 
                    {
                        "F1"
                    }
                }
            };

            var f2 = new List<FooBar>()
            {
                new FooBar()
                {
                    Name = "f1",
                    Type = FizzType.Foo
                }
            };

            Assert.True(_comparer.Equals(f1, f2));
        }

        [Fact]
        public void List_Match_Cap_Name_Type_Same_Alternate_Valid()
        {
            var f1 = new List<FooBar>() 
            {
                new FooBar() 
                {
                    Name = "f2",
                    Type = FizzType.Foo,
                    AlternativeNames = new List<string>() 
                    {
                        "f1"
                    }
                }
            };

            var f2 = new List<FooBar>()
            {
                new FooBar()
                {
                    Name = "F1",
                    Type = FizzType.Foo
                }
            };

            Assert.True(_comparer.Equals(f1, f2));
        }

        [Fact]
        public void List_Unmatch_Name_Invalid()
        {
            var f1 = new List<FooBar>() 
            {
                new FooBar() 
                {
                    Name = "f2",
                    Type = FizzType.Foo
                }
            };

            var f2 = new List<FooBar>()
            {
                new FooBar()
                {
                    Name = "f1",
                    Type = FizzType.Foo
                }
            };

            Assert.False(_comparer.Equals(f1, f2));
        }

        [Fact]
        public void List_Unmatch_Type_Invalid()
        {
            var f1 = new List<FooBar>() 
            {
                new FooBar() 
                {
                    Name = "f1",
                    Type = FizzType.Five
                }
            };

            var f2 = new List<FooBar>()
            {
                new FooBar()
                {
                    Name = "f1",
                    Type = FizzType.Foo
                }
            };

            Assert.False(_comparer.Equals(f1, f2));
        }

        [Fact]
        public void List_Unmatch_Alternate_Name_Invalid()
        {
            var f1 = new List<FooBar>() 
            {
                new FooBar() 
                {
                    Name = "f2",
                    Type = FizzType.Foo,
                    AlternativeNames = new List<string>() 
                    { 
                        "f3" 
                    }
                }
            };

            var f2 = new List<FooBar>()
            {
                new FooBar()
                {
                    Name = "f1",
                    Type = FizzType.Foo
                }
            };

            Assert.False(_comparer.Equals(f1, f2));
        }

        [Fact]
        public void List_Unmatch_First_Empty_Invalid()
        {
            var f1 = new List<FooBar>();

            var f2 = new List<FooBar>()
            {
                new FooBar()
                {
                    Name = "f1",
                    Type = FizzType.Foo
                }
            };

            Assert.False(_comparer.Equals(f1, f2));
        }

        [Fact]
        public void List_Unmatch_Second_Empty_Invalid()
        {
            var f2 = new List<FooBar>();

            var f1 = new List<FooBar>()
            {
                new FooBar()
                {
                    Name = "f1",
                    Type = FizzType.Foo
                }
            };

            Assert.False(_comparer.Equals(f1, f2));
        }

        [Fact]
        public void List_Unmatch_First_Null_Invalid()
        {
            var f2 = new List<FooBar>()
            {
                new FooBar()
                {
                    Name = "f1",
                    Type = FizzType.Foo
                }
            };

            Assert.False(_comparer.Equals(null, f2));
        }

        [Fact]
        public void List_Unmatch_Second_Null_Invalid()
        {
            var f2 = new List<FooBar>()
            {
                new FooBar()
                {
                    Name = "f1",
                    Type = FizzType.Foo
                }
            };

            Assert.False(_comparer.Equals(f2, null));
        }

        [Fact]
        public void List_Unmatch_Null_Invalid()
        {
            Assert.False(_comparer.Equals(null, null));
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
        public void Match_Name_Default_Type_Valid()
        {
            var f1 = new FooBar()
            {
                Name = "f1"
            };

            var f2 = new FooBar()
            {
                Name = "f1"
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
        public void Match_Alternative_Second_Names_Valid()
        {
            var f1 = new FooBar()
            {
                Name = "f1",
                Type = FizzType.Foo
            };

            var f2 = new FooBar()
            {
                Name = "f2",
                Type = FizzType.Foo,
                AlternativeNames = new List<string>() { "f1" }
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
        public void Unmatch_Default_Type_Invalid()
        {
            var f1 = new FooBar()
            {
                Name = "f1"
            };

            var f2 = new FooBar()
            {
                Name = "f1",
                Type = FizzType.Five
            };

            Assert.False(_comparer.Equals(f1, f2));
        }

        [Fact]
        public void Unmatch_Alternative_First_Names_Invalid()
        {
            var f1 = new FooBar()
            {
                Name = "f1",
                Type = FizzType.Zebra,
                AlternativeNames = new List<string>() { "ff1" }
            };

            var f2 = new FooBar()
            {
                Name = "f2",
                Type = FizzType.Zebra
            };

            Assert.False(_comparer.Equals(f1, f2));
        }

        [Fact]
        public void Unmatch_Alternative_Second_Names_Invalid()
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

        [Fact]
        public void First_Empty_Invalid()
        {
            var f1 = new FooBar();

            var f2 = new FooBar()
            {
                Name = "f2",
                Type = FizzType.Zebra
            };

            Assert.False(_comparer.Equals(f1, f2));
        }

        [Fact]
        public void First_Name_Empty_Invalid()
        {
            var f1 = new FooBar() 
            {
                Type = FizzType.Zebra
            };

            var f2 = new FooBar()
            {
                Name = "f2",
                Type = FizzType.Zebra
            };

            Assert.False(_comparer.Equals(f1, f2));
        }

        [Fact]
        public void First_Type_Empty_Invalid()
        {
            var f1 = new FooBar() 
            {
                Name = "f1"
            };

            var f2 = new FooBar()
            {
                Name = "f2",
                Type = FizzType.Zebra
            };

            Assert.False(_comparer.Equals(f1, f2));
        }

        [Fact]
        public void Second_Name_Empty_Invalid()
        {
            var f2 = new FooBar() 
            {
                Type = FizzType.Zebra
            };

            var f1 = new FooBar()
            {
                Name = "f2",
                Type = FizzType.Zebra
            };

            Assert.False(_comparer.Equals(f1, f2));
        }
        
        [Fact]
        public void Second_Type_Empty_Invalid()
        {
            var f2 = new FooBar() 
            {
                Name = "f1"
            };

            var f1 = new FooBar()
            {
                Name = "f2",
                Type = FizzType.Zebra
            };

            Assert.False(_comparer.Equals(f1, f2));
        }

        [Fact]
        public void Second_Empty_Invalid()
        {

            var f1 = new FooBar()
            {
                Name = "f1",
                Type = FizzType.Zebra
            };

            var f2 = new FooBar();

            Assert.False(_comparer.Equals(f1, f2));
        }        
    }
}
