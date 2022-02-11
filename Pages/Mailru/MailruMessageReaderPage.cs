using OpenQA.Selenium;
using Pages.Interfaces;

namespace Pages.Mailru
{
    public class MailruMessageReaderPage : BasePage, IMessageReaderPage
    {
        private By _backToMailboxButtonLocator = By.XPath("//a[text() = 'Почта']");

        private By _deleteMessageButtonLocator = By.XPath("//*[@title = 'Удалить']");

        private By _authorContactTextLocator = By.XPath("//*[contains(@class, 'letter-contact')]");

        private By _subjectTextLocator = By.XPath("//*[contains(@class, 'thread-subject')]");

        private By _letterBodyLocator = By.XPath("//*[@class = 'letter-body']");

        private By _isInBacketTextLocator = By.XPath("//*[@class = 'notify__message__text']");


        public MailruMessageReaderPage(IWebDriver driver) : base(driver)
        {
            logger = NLog.LogManager.GetCurrentClassLogger();
        }


        public IMailboxPage BackToMailbox()
        {
            Waiters.WaitUntilDisplayElement(Driver, _backToMailboxButtonLocator);
            Driver.FindElement(_backToMailboxButtonLocator).Click();
            return new MailruMailboxPage(Driver);
        }

        public IMessageReaderPage DeleteMessage()
        {
            Waiters.WaitUntilDisplayElement(Driver, _deleteMessageButtonLocator);
            Driver.FindElement(_deleteMessageButtonLocator).Click();
            Waiters.WaitUntilDisplayElement(Driver, _isInBacketTextLocator);
            return this;
        }

        public string GetAuthor()
        {
            Waiters.WaitUntilDisplayElement(Driver, _authorContactTextLocator);
            return Driver.FindElement(_authorContactTextLocator).Text;
        }

        public string GetAuthorEmail()
        {
            Waiters.WaitUntilDisplayElement(Driver, _authorContactTextLocator);
            return Driver.FindElement(_authorContactTextLocator).GetAttribute("title");
        }

        public string GetSubject()
        {
            Waiters.WaitUntilDisplayElement(Driver, _subjectTextLocator);
            return Driver.FindElement(_subjectTextLocator).Text;
        }

        public string GetText()
        {
            Waiters.WaitUntilDisplayElement(Driver, _letterBodyLocator);
            return Driver.FindElement(_letterBodyLocator).Text;
        }
    }
}