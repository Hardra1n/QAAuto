using Microsoft.Extensions.Configuration;
using ModelNService.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace ModelNService.Service
{
    public class ConfigProvider
    {
        public T Get<T>() where T: new()
        {
            var settings = new ConfigurationBuilder()
                .AddJsonFile(AccountCreditsProvider.GetJsonPath())
                .Build();
            return settings.Get<T>();
        }
    }
}
