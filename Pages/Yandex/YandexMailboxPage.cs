using OpenQA.Selenium;
using Pages.Interfaces;
using System.Threading;

namespace Pages.Yandex
{
    public class YandexMailboxPage : BasePage, IMailboxPage
    {
        public static string url = "https://mail.yandex.by/";

        By _messageComposerButtonLocator = By.XPath("//a[contains(@class, 'mail-ComposeButton')]");


        public YandexMailboxPage(IWebDriver driver) : base(driver) { }


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
            Waiters.WaitUntilDisplayElement(Driver, _messageComposerButtonLocator);
            Driver.FindElement(_messageComposerButtonLocator).Click();
            return new YandexMessageComposerPage(Driver);
        }

        public IHomePage GoToHomePage()
        {
            Driver.Url = YandexHomePage.url;
            return new YandexHomePage(Driver);
        }
    }
}
