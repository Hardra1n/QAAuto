using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    [TestFixture]
    public class BaseTest
    {
        ChromeOptions _options;

        protected BaseTest()
        {
            _options = new ChromeOptions();
            _options.AddArgument("headless");
            _options.AddArgument("incognito");
        }

        protected IWebDriver GetNewChromeDriver()
        {
            return new ChromeDriver(_options);
        }
    }
}
