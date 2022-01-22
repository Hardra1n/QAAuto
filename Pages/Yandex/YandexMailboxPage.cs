using OpenQA.Selenium;
using Pages.Interfaces;

namespace Pages.Yandex
{
    public class YandexMailboxPage : Page, IMailboxPage
    {
        public static string url = "https://mail.yandex.by/";

        By _messageComposerButton = By.XPath("//a[contains(@class, 'mail-ComposeButton')]");

        public YandexMailboxPage(IWebDriver driver)
        {
            Driver = driver;
        }

        IWebDriver Driver { get; set; }

        public IMessageComposerPage OpenMessageComposer()
        {
            Waiters.WaitUntilDisplayElement(Driver, _messageComposerButton);
            Driver.FindElement(_messageComposerButton).Click();
            return new YandexMessageComposerPage(Driver);
        }
    }
}
