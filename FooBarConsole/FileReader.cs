using System;
using System.IO;
using FooBarConsole.Interfaces;

namespace FooBarConsole
{
    /// <summary>
    /// Read file content
    /// </summary>
    public class FileReader : IFileReader
    {
        private readonly IConfigurationReader _config;

        public FileReader(IConfigurationReader config) 
        {
            _config = config;
        }

        public string ReadFile()
        {
            try
            {
                using (StreamReader file = File.OpenText(_config.GetInternalFile()))
                {
                    return file.ReadToEnd();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}