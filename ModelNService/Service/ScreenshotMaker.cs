using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.IO;

namespace ModelNService.Service
{
    public static class ScreenshotMaker
    {
        public static void TakeScreenshot(IWebDriver driver)
        {
            Screenshot screen = driver.TakeScreenshot();
            screen.SaveAsFile(GetFileName(), ScreenshotImageFormat.Png);
        }
        private static string GetFileName()
        {
            string time = DateTime.Now.ToString();
            string testname = TestContext.CurrentContext.Test.FullName;
            return time + ' ' + testname + ".png";
        }
    }
}
