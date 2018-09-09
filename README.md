# FooBar

I build .NET Core 2.0 Console application instead of building .NET Standard. .NET Standard is for building a library that can be used across platforms on .NET 4.7 or .NET Core. 

.NET Standard is not an implementation, instead it is a contract between different .NET versions and different platforms for building library that targetting future .NET releases or cross platforms. Further refactoring can be made by splitting common classes into a .NET Standard library project for future sharing between different projects.

I assume that we are trying to compare two lists of FooBar. One externally from the URL and one from an internal file. I use JSON as the file format to be easily deserialised back to C# model class.

# Steps to run
- Clone the repo using any git compatible client
- Use Visual Studio 2017 to open the solution and run it or on the .net core command line, run `dotnet run`
- To run the test cases, use Visual Studio 2017 Test Explorer or on the .net core command line, run `dotnet test`

Application.cs is the main class to execute the task of comparing between two lists of FooBar and two individual FooBar just to show that the class TypeNameComparer.cs class is working and it will show "True" if both lists are equal. Most of the scenarios will be tested in the test cases.

I use Autofac as the IoC Container, Moq for test mocking and xUnit as a testing framework.
