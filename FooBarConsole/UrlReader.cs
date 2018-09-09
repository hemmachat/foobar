using System;
using System.Net;
using FooBarConsole.Interfaces;

namespace FooBarConsole
{
    /// <summary>
    /// Read file content from an URL
    /// </summary>
    public class UrlReader : IFileReader
    {
        private readonly IConfigurationReader _config;

        public UrlReader(IConfigurationReader config)
        {
            _config = config;
        }

        /// <summary>
        /// Read URL file based on application configuration
        /// </summary>
        /// <returns>File content</returns>
        public string ReadFile()
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    return wc.DownloadString(_config.GetExternalUrl());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}