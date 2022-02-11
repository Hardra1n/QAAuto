using OpenQA.Selenium;
using Pages.Interfaces;

namespace Pages.Mailru
{
    public class MailruMailboxPage : BasePage, IMailboxPage
    {
        public const string URL = "https://e.mail.ru/inbox";

        private By _messageComposerButtonLocator = By.XPath("//a[contains(@class, 'compose-button')]");


        public MailruMailboxPage(IWebDriver driver) : base(driver)
        {
            logger = NLog.LogManager.GetCurrentClassLogger();
        }


        public IMessageReaderPage OpenNewMessageFromConcreteAuthor(string author)
        {
            string xPath = GetNewMessageFromConcreteAuthorLocator(author);
            By locator = By.XPath(xPath);
            Waiters.WaitUntilDisplayElement(Driver, locator);
            Driver.FindElement(locator).Click();

            logger.Info($"Mailru user opened new message from {author}.");
            return new MailruMessageReaderPage(Driver);
        }


        public IMessageComposerPage OpenMessageComposer()
        {
            Waiters.WaitUntilDisplayElement(Driver, _messageComposerButtonLocator);
            Driver.FindElement(_messageComposerButtonLocator).Click();

            logger.Info("Mailru user navigated to message composer page.");
            return new MailruMessageComposerPage(Driver);
        }

        public IHomePage GoToHomePage()
        {
            logger.Info("Mailru user navigated to home page.");
            return new MailruHomePage(Driver);
        }

        private string GetNewMessageFromConcreteAuthorLocator(string author)
            => $"//a[.//*[contains(@title, '{author}')] and .//*[contains(@title, 'Пометить прочитанным')]]";
    }
}