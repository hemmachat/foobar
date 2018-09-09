using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using FooBarConsole.Models;
using FooBarConsole.Interfaces;

namespace FooBarConsole
{
    /// <summary>
    /// Fetch external URL list of FooBar
    /// </summary>
    public class ExternalUrlFetcher : IExternalFetcher
    {
        private readonly IFileReader _reader;

        public ExternalUrlFetcher(IFileReader reader)
        {
            _reader = reader;
        }

        public List<FooBar> GetExternalFooBar()
        {
            try
            {
                return JsonConvert.DeserializeObject<List<FooBar>>(_reader.ReadFile());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
