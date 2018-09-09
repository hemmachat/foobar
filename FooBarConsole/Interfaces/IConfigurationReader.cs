namespace FooBarConsole.Interfaces
{
    public interface IConfigurationReader
    {
         string GetInternalFile();
         string GetExternalUrl();
    }
}