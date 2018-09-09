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
    public class ExternalUrlFetcher : IExternalFetcher
    {
        private readonly IConfigurationReader _config;
        
        public ExternalUrlFetcher(IConfigurationReader config)
        {
            _config = config;
        }

        public List<FooBar> GetExternalFooBar()
        {

            using (WebClient wc = new WebClient())
            {
                try
                {
                    var json = wc.DownloadString(_config.GetExternalUrl());
                
                    return JsonConvert.DeserializeObject<List<FooBar>>(json);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
