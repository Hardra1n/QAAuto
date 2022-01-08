using OpenQA.Selenium;
using Pages.Interfaces;

namespace Pages.Yandex
{
    public class YandexMailboxPage : IMailboxPage
    {
        public YandexMailboxPage(IWebDriver driver)
        {
            Driver = driver;
        }

        IWebDriver Driver { get; set; }
    }
}
