using OpenQA.Selenium;
using System;

namespace Pages
{
    public abstract class Page
    {
        public void CheckForCorrectPage(IWebDriver driver, string pageTitle)
        {
            try
            {
                Waiters.WaitUntilTitleEquals(driver, pageTitle);
            }
            catch (WebDriverTimeoutException ex)
            {
                string additionalMessage = '\n' + "Incorrect driver url";
                throw new WebDriverTimeoutException(ex.Message + additionalMessage);
            }
        }
    }
}
