using OpenQA.Selenium;

namespace Pages.Yandex
{
    public class YandexMailboxPage
    {
        public YandexMailboxPage(IWebDriver driver)
        {
            Driver = driver;
        }

        IWebDriver Driver { get; set; }
    }
}
