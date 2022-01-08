using OpenQA.Selenium;
using Pages.Interfaces;
using System;
using System.Threading;

namespace Pages.Yandex
{
    public class YandexHomePage : IHomePage
    {
        string _urlToMailbox = "https://mail.yandex.by/";

        public YandexHomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        IWebDriver Driver { get; set; }

        public IMailboxPage GoToMailboxPage()
        {
            Thread.Sleep(10000);
            Driver.Url = _urlToMailbox;
            YandexMailboxPage mailboxPage = new YandexMailboxPage(Driver);
            return mailboxPage;
        }
    }
}
