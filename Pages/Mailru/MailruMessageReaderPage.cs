using OpenQA.Selenium;
using Pages.Interfaces;
using System.Threading;

namespace Pages.Mailru
{
    public class MailruMessageReaderPage : IMessageReaderPage
    {
        By _backToMailboxButton = By.XPath("//a[text() = 'Почта']");

        By _deleteMessageButton = By.XPath("//*[@title = 'Удалить']");

        By _authorContactText = By.XPath("//*[contains(@class, 'letter-contact')]");

        By _subjectText = By.XPath("//*[contains(@class, 'thread-subject')]");

        By _letterBody = By.XPath("//*[@class = 'letter-body']");

        By _isInBacketText = By.XPath("//*[@class = 'notify__message__text']");

        public MailruMessageReaderPage(IWebDriver driver)
        {
            Driver = driver;
        }

        IWebDriver Driver { get; set; }

        public IMailboxPage BackToMailbox()
        {
            Waiters.WaitUntilDisplayElement(Driver, _backToMailboxButton);
            Driver.FindElement(_backToMailboxButton).Click();
            return new MailruMailboxPage(Driver);
        }

        public IMessageReaderPage DeleteMessage()
        {
            Waiters.WaitUntilDisplayElement(Driver, _deleteMessageButton);
            Driver.FindElement(_deleteMessageButton).Click();
            Waiters.WaitUntilDisplayElement(Driver, _isInBacketText);
            return this;
        }

        public string GetAuthor()
        {
            Waiters.WaitUntilDisplayElement(Driver, _authorContactText);
            return Driver.FindElement(_authorContactText).Text;
        }

        public string GetAuthorEmail()
        {
            Waiters.WaitUntilDisplayElement(Driver, _authorContactText);
            return Driver.FindElement(_authorContactText).GetAttribute("title");
        }

        public string GetSubject()
        {
            Waiters.WaitUntilDisplayElement(Driver, _subjectText);
            return Driver.FindElement(_subjectText).Text;
        }

        public string GetText()
        {
            Waiters.WaitUntilDisplayElement(Driver, _letterBody);
            return Driver.FindElement(_letterBody).Text;
        }
    }
}