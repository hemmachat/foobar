using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using FooBarConsole.Models;

namespace FooBarConsole.Interfaces
{
    public class FooBarExternalUrlFetcher : IFooBarExternalFetcher
    {
        private const string EXTERNAL_URL = "ExternalFooBarUrl";

        public List<FooBar> GetExternalFooBar()
        {
            var externalFooBarUrl = ConfigurationManager.AppSettings[EXTERNAL_URL];

            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(externalFooBarUrl);
                
                return JsonConvert.DeserializeObject<List<FooBar>>(json);
            }
        }
    }
}
