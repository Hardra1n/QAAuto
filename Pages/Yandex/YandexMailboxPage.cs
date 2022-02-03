using OpenQA.Selenium;
using Pages.Interfaces;

namespace Pages.Yandex
{
    public class YandexMailboxPage : BasePage, IMailboxPage
    {
        public const string URL = "https://mail.yandex.by/";

        private By _messageComposerButtonLocator = By.XPath("//a[contains(@class, 'mail-ComposeButton')]");


        public YandexMailboxPage(IWebDriver driver) : base(driver) { }


        public IMessageReaderPage OpenNewMessageFromConcreteAuthor(string author)
        {
            By locator = By.XPath(GetNewMessageFromConcreteAuthorLocator(author));
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

        private string GetNewMessageFromConcreteAuthorLocator(string author)
            => $"//a[.//*[contains(@title, {author})] and .//*[contains(@title, 'Отметить как прочитанное')]]";
    }
}
