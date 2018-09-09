# FooBar

I build .NET Core 2.0 Console application as .NET Standard is for building a library that can be used cross platforms on .NET 4.7 or .NET Core. .NET Standard is not an implementation, instead it is kind of contract between different .NET across different platforms. Further refactoring can be made by splitting common classes into a .NET Standard library project for future sharing between different projects.

I assume that we are trying to compare two lists of FooBar. One externally from the URL and one from an internal file. I use JSON as the file format to be easily deserialised back to C# model class.

- To run the application, use Visual Studio 2017 or on the .net core command line, run "dotnet run"
- To run the test cases, use Visual Studio 2017 Test Executable or on the .net core command line, run "dotnet test"

Application.cs is a executable class to execute the task of comparing between two lists of FooBar and two individual FooBar just to show that the class TypeNameComparer.cs class is working and it will show "True" if both lists are equal. Most of the scenarios will be tested in the test cases.

I use Autofac as the IoC Container, Moq for test mocking and xUnit as a testing framework.
