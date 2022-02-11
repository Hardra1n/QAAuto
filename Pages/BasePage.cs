using NLog;
using OpenQA.Selenium;

namespace Pages
{
    public abstract class BasePage
    {
        protected static Logger logger;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        protected IWebDriver Driver { get; set; }
    }
}
