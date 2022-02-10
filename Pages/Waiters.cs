using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace Pages
{
    static public class Waiters
    {
        private static TimeSpan _waitTimer = new TimeSpan(0, 0, 40);

        static public void WaitUntilDisplayElement(IWebDriver driver, By locator) 
            => new WebDriverWait(driver, _waitTimer).Until(driver => driver.FindElement(locator).Displayed);

        static public bool WaitUntilNotVisable(IWebDriver driver, By locator)
            => new WebDriverWait(driver, _waitTimer).Until(driver => !driver.FindElement(locator).Displayed);

        static public bool WaitUntilNotEnable(IWebDriver driver, By locator)
            => new WebDriverWait(driver, _waitTimer).Until(driver => !driver.FindElement(locator).Enabled);

        static public bool WaitUntilTitleEquals(IWebDriver driver, string title)
            => new WebDriverWait(driver, _waitTimer).Until(driver => driver.Title == title);

        static public bool WaitUntilTitleContains(IWebDriver driver, string substring) 
            => new WebDriverWait(driver, _waitTimer).Until(driver => driver.Title.Contains(substring));
    }
}
