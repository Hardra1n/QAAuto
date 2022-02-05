using Microsoft.Extensions.Configuration;
using ModelNService.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace ModelNService.Service
{
    public class ConfigProvider
    {
        private const string _accountCredentialsPath = @"Resource\AccountCredentials.json";

        private Dictionary<Type, string> _configPathDictionary = new()
        {
            { new AccountCredentials().GetType(), _accountCredentialsPath}
        };

        public T Get<T>() where T: new()
        {
            T obj = new();
            var settings = new ConfigurationBuilder()
                .AddJsonFile(_configPathDictionary[typeof(T)])
                .Build();
            obj = settings.Get<T>();
            return obj;
        }
    }
}
