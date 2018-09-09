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

        /// <summary>
        /// Read the file based on application configuration
        /// </summary>
        /// <returns>File content</returns>
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