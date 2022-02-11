using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelNService.Service
{
    public class AccountCreditsProvider
    {
        private const string QAEnvironmentPath = @"Resource\AccountCredentials.qa.json";

        private const string DevEnvironmentPath = @"Resource\AccountCredentials.dev.json";

        public static string GetJsonPath()
        {
            switch(TestContext.Parameters["environment"])
            {
                case ("dev"):
                    return DevEnvironmentPath;
                case ("qa"):
                default:
                    return QAEnvironmentPath;
            }
        }
    }
}
