using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    public static class Driver
    {
        public static IWebDriver GetChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();

            options.AddArgument("headless");
            options.AddArgument("incognito");
            options.AddArgument("window-size=1400,900");

            return new ChromeDriver(options);
        }
    }
}
