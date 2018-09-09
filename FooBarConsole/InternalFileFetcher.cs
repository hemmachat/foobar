using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;
using FooBarConsole.Models;
using System;
using FooBarConsole.Interfaces;

namespace FooBarConsole
{
    public class InternalFileFetcher : IInternalFetcher
    {
        private readonly IConfigurationReader _config;

        public InternalFileFetcher(IConfigurationReader config) 
        {
            _config = config;
        }

        public List<FooBar> GetInternalFooBar()
        {
            try
            {
                using (StreamReader file = File.OpenText(_config.GetInternalFile()))
                {
                    return JsonConvert.DeserializeObject<List<FooBar>>(file.ReadToEnd());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}