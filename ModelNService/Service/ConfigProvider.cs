using Microsoft.Extensions.Configuration;
using ModelNService.Model;
using System;
using System.IO;

namespace ModelNService.Service
{
    public static class ConfigProvider
    {
        private static string _solutionDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;

        private static string _accountCredentialsPath = _solutionDirectory + @"\ModelNService\Resource\AccountCredentials.json";

        public static T Get<T>() where T: new()
        {
            T obj = new T();
            var settings = new ConfigurationBuilder()
                .AddJsonFile(GetFilePathByType<T>())
                .Build();
            obj = settings.Get<T>();
            return obj;
        }

        private static string GetFilePathByType<T>() where T : new()
        {
            if (typeof(T) == new AccountCredentials().GetType())
            {
                return _accountCredentialsPath;
            }

            return null;
        }
    }
}
