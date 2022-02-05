using ModelNService.Model;
using ModelNService.Service;
using OpenQA.Selenium;

namespace Tests
{
    public class BaseTest
    {
        protected AccountCredentials accounts = new ConfigProvider().Get<AccountCredentials>();

        protected IWebDriver _driver;
    }
}
