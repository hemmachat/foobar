namespace FooBarConsole.Interfaces
{
    /// <summary>
    /// Interface for reading configuration values
    /// </summary>
    public interface IConfigurationReader
    {
         string GetInternalFile();
         string GetExternalUrl();
    }
}