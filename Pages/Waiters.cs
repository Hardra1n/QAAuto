using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Pages
{
    static public class Waiters
    {
        private static TimeSpan _waitTimer = new TimeSpan(0, 0, 30);

        static public void WaitUntilDisplayElement(IWebDriver driver, By locator)
        {
            WebDriverWait waiter = WaiterInitializer(driver);
            waiter.Until(driver =>
            {
                IWebElement element = driver.FindElement(locator);
                if (element.Displayed)
                {
                    return true;
                }
                return false;
            });
        }

        static private WebDriverWait WaiterInitializer(IWebDriver driver)
        {
            WebDriverWait waiter = new WebDriverWait(driver, _waitTimer);
            waiter.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
            return waiter;
        }
    }
}
