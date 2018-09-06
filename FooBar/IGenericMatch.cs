using System;
using System.Collections.Generic;
using System.Text;

namespace FooBar
{
    interface IGenericMatch
    {
        bool IsMatch(FooBar firstFoo, FooBar secondFoo);
        bool IsTypeMatch(FooBar firstFoo, FooBar secondFoo);
        bool IsNameMatch(FooBar firstFoo, FooBar secondFoo);
    }
}
