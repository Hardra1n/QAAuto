using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.IO;

namespace ModelNService.Service
{
    public static class ScreenshotMaker
    {
        private const string directoryName = "screenshots/";

        public static void TakeScreenshot(IWebDriver driver)
        {
            Screenshot screen = driver.TakeScreenshot();
            CreateDirectory();
            screen.SaveAsFile(GetFileName(), ScreenshotImageFormat.Png);
        }

        private static void CreateDirectory()
        {
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
        }

        private static string GetFileName()
            => directoryName
                + DateTime.Now.Date.ToShortDateString() + ' '
                + DateTime.Now.Hour + 'h'
                + DateTime.Now.Minute + 'm' + ' '
                + TestContext.CurrentContext.Test.Name
                + ".png";
    }
}
