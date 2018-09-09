using System.Configuration;
using FooBarConsole.Interfaces;
using System;

namespace FooBarConsole
{
    public class ConfigurationReader : IConfigurationReader
    {
        private const string EXTERNAL_URL = "ExternalFooBarUrl";
        private const string INTERNAL_FILE = "InternalFooBarFile";

        public string GetExternalUrl()
        {
            try
            {
                return ConfigurationManager.AppSettings[EXTERNAL_URL];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetInternalFile()
        {
            try
            {
                return ConfigurationManager.AppSettings[INTERNAL_FILE];
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}