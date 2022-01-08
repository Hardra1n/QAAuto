using OpenQA.Selenium;
using Pages.Interfaces;
using System;

namespace Pages.Yandex
{
    public class YandexHomePage : IHomePage
    {
        string _urlToMailBox;

        public YandexHomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        IWebDriver Driver { get; set; }

        public IMailboxPage GoToMailboxPage()
        {
            throw new NotImplementedException();
        }
    }
}
