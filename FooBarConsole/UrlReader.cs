using System;
using System.Net;
using FooBarConsole.Interfaces;

namespace FooBarConsole
{
    public class UrlReader : IFileReader
    {
        private readonly IConfigurationReader _config;

        public UrlReader(IConfigurationReader config)
        {
            _config = config;
        }

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