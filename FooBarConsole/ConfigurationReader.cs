using System.Configuration;
using FooBarConsole.Interfaces;
using System;

namespace FooBarConsole
{
    /// <summary>
    /// Read application configuration
    /// </summary>
    public class ConfigurationReader : IConfigurationReader
    {
        private const string EXTERNAL_URL = "ExternalFooBarUrl";
        private const string INTERNAL_FILE = "InternalFooBarFile";

        /// <summary>
        /// Fetch external URL
        /// </summary>
        /// <returns>URL of the external FooBar</returns>
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

        /// <summary>
        /// Fetch internal file path
        /// </summary>
        /// <returns>Path of the internal FooBar file</returns>
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