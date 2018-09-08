using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;
using FooBarConsole.Models;
using System;

namespace FooBarConsole.Interfaces
{
    public class FooBarInternalFileFetcher : IFooBarInternalFetcher
    {
        private const string INTERNAL_FILE = "InternalFooBarFile";

        public List<FooBar> GetInternalFooBar()
        {
            var internalFooBarFile = ConfigurationManager.AppSettings[INTERNAL_FILE];

            try
            {
                using (StreamReader file = File.OpenText(internalFooBarFile))
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