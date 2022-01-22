using OpenQA.Selenium;
using Pages.Interfaces;

namespace Pages.Mailru
{
    public class MailruMessageReaderPage : IMessageReaderPage
    {
        By _closeMessageButton = By.XPath("//*[@title = 'Вернуться']");

        By _deleteMessageButton = By.XPath("//*[@title = 'Удалить']");

        By _authorContactText = By.XPath("//*[contains(@class, 'letter-contact')]");

        By _subjectText = By.XPath("//*[contains(@class, 'thread-subject')]");

        By _letterBody = By.XPath("//*[@class = 'letter-body']");

        public MailruMessageReaderPage(IWebDriver driver)
        {
            Driver = driver;
        }

        IWebDriver Driver { get; set; }

        public IMailboxPage CloseMessage()
        {
            Waiters.WaitUntilDisplayElement(Driver, _closeMessageButton);
            Driver.FindElement(_closeMessageButton).Click();
            return new MailruMailboxPage(Driver);
        }

        public IMailboxPage DeleteMessage()
        {
            Waiters.WaitUntilDisplayElement(Driver, _deleteMessageButton);
            Driver.FindElement(_deleteMessageButton).Click();
            return new MailruMailboxPage(Driver);
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