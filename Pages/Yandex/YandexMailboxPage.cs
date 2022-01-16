using OpenQA.Selenium;
using Pages.Interfaces;

namespace Pages.Yandex
{
    public class YandexMailboxPage : Page, IMailboxPage
    {
        public YandexMailboxPage(IWebDriver driver)
        {
            Driver = driver;
        }

        IWebDriver Driver { get; set; }

        public IMessageComposerPage OpenMessageComposer()
        {
            throw new System.NotImplementedException();
        }
    }
}
