using OpenQA.Selenium;
using Pages.Interfaces;
using System.Threading;

namespace Pages.Yandex
{
    public class YandexMailboxPage : IMailboxPage
    {
        public static string url = "https://mail.yandex.by/";

        By _messageComposerButton = By.XPath("//a[contains(@class, 'mail-ComposeButton')]");

        public YandexMailboxPage(IWebDriver driver)
        {
            Driver = driver;
        }

        IWebDriver Driver { get; set; }

        public IMessageReaderPage OpenNewMessageFromConcreteAuthor(string author)
        {
            string xPath = $"//a[" +
                              $".//*[contains(@title, '{author}')] and " +
                              $".//*[contains(@title, 'Отметить как прочитанное')]]";
            By locator = By.XPath(xPath);
            Waiters.WaitUntilDisplayElement(Driver, locator);
            Driver.FindElement(locator).Click();
            return new YandexMessageReaderPage(Driver);
        }

        public IMessageComposerPage OpenMessageComposer()
        {
            Waiters.WaitUntilDisplayElement(Driver, _messageComposerButton);
            Driver.FindElement(_messageComposerButton).Click();
            return new YandexMessageComposerPage(Driver);
        }
    }
}
