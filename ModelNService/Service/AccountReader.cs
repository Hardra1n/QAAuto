using Newtonsoft.Json.Linq;
using System.IO;
using System;

namespace ModelNService.Service
{
    public class AccountReader
    {
        private static string _solutionDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;

        private string filePath = _solutionDirectory + @"\ModelNService\Resource\AccountCredentials.json";

        private JObject _jObject;

        public AccountReader()
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                _jObject = JObject.Parse(reader.ReadToEnd());
            }
        }

        public string GetValue(string domainName, string nodeName)
        {
            return _jObject[domainName][nodeName].ToString();
        }

    }
}
