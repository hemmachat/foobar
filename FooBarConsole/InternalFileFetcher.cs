using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;
using FooBarConsole.Models;
using System;
using FooBarConsole.Interfaces;

namespace FooBarConsole
{
    /// <summary>
    /// Fetch internal list of FooBar
    /// </summary>
    public class InternalFileFetcher : IInternalFetcher
    {
        private readonly IFileReader _reader;

        public InternalFileFetcher(IFileReader reader) 
        {
            _reader = reader;
        }

        public List<FooBar> GetInternalFooBar()
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