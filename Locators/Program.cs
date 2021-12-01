using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;

namespace Locators
{
    class Program
    {
        static void Main(string[] args)
        {
            WebDriver driver = new EdgeDriver();
            driver.Url = "https://www.bbc.com/sport";

            IWebElement elem = driver.FindElement(By.Id("sp-nav-all-sport-button"));
            var temp = driver.FindElements(By.XPath("/q"));


            driver.Close();
        }
    }
}
