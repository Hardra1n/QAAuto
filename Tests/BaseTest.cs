using ModelNService.Model;
using ModelNService.Service;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace Tests
{
    public class BaseTest
    {
        protected AccountCredentials accounts = new ConfigProvider().Get<AccountCredentials>();

        protected IWebDriver _driver;

        [TearDown]
        public void ScreenshotOnFailure()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
            {
                NLog.LogManager.GetCurrentClassLogger().Error("Test was failed, created screenshot");
                ScreenshotMaker.TakeScreenshot(_driver);
            }
        }
    }
}
