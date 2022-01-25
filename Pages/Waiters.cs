using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Pages
{
    static public class Waiters
    {
        private static TimeSpan _waitTimer = new TimeSpan(0, 0, 20);


        static private WebDriverWait WaiterInitializer(IWebDriver driver)
        {
            WebDriverWait waiter = new WebDriverWait(driver, _waitTimer);
            waiter.IgnoreExceptionTypes(typeof(NoSuchElementException), 
                                        typeof(StaleElementReferenceException));
            return waiter;
        }


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

        static public bool WaitUntilNotVisable(IWebDriver driver, By locator)
        {
            WebDriverWait waiter = WaiterInitializer(driver);
            return waiter.Until(driver =>
            {
                IWebElement element = driver.FindElement(locator);
                if (!element.Displayed)
                {
                    return true;
                }
                return false;
            });
        }

        static public bool WaitUntilTitleEquals(IWebDriver driver, string title)
        {
            WebDriverWait waiter = WaiterInitializer(driver);
            return waiter.Until(driver =>
            {
                if (driver.Title == title)
                {
                    return true;
                }
                return false;
            });
        }

        static public bool WaitUntilTitleContains(IWebDriver driver, string substring)
        {
            WebDriverWait waiter = WaiterInitializer(driver);
            return waiter.Until(driver =>
            {
                string driverTitle = driver.Title;
                if (driverTitle.Contains(substring))
                {
                    return true;
                }
                return false;
            });
        }
    }
}
