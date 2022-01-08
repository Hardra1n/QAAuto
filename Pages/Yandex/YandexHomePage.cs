using OpenQA.Selenium;
using Pages.Interfaces;
using System;

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
            Driver.Url = _urlToMailbox;
            YandexMailboxPage mailboxPage = new YandexMailboxPage(Driver);
            return (IMailboxPage)mailboxPage;
        }
    }
}
