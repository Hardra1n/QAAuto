using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace ModelNService.Driver
{
    public class DriverManager
    {
        private static IWebDriver _driver;

        private DriverManager() { }

        public static IWebDriver GetWebDriver() 
        {
            if (_driver == null)
            {
                //_driver = new ChromeDriver(GetChromeOptions());
                _driver = new FirefoxDriver(GetFirefoxOptions());
            }

            return _driver;
        }

        public static void CloseDriver()
        {
            _driver.Close();
            _driver = null;
        }

        private static ChromeOptions GetChromeOptions()
        {
            var options = new ChromeOptions();

            options.AddArgument("headless");
            options.AddArgument("incognito");
            options.AddArgument("window-size=1400,900");

            return options;
        }

        private static FirefoxOptions GetFirefoxOptions()
        {
            var options = new FirefoxOptions();

            options.AddArgument("--headless");
            //options.AddArgument("--private");
            options.AddArgument("--width=1400");
            options.AddArgument("--height=900");

            return options;
        }

    }
}
