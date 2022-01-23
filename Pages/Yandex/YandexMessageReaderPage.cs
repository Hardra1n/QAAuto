using OpenQA.Selenium;
using Pages.Interfaces;

namespace Pages.Yandex
{
    public class YandexMessageReaderPage : IMessageReaderPage
    {
        By _subjectText = By.XPath("//*[contains(@class, 'Title__subject')]");

        By _letterBody = By.XPath("//*[contains(@class, 'MessageBody__body')]/div");

        By _senderName = By.XPath("//*[contains(@class, 'SenderName')]");

        By _senderEmail = By.XPath("//*[contains(@class, 'SenderEmail')]");

        By _deleteButton = By.XPath("//*[contains(@title, 'Удалить')]");

        By _backToMailboxButton = By.XPath("//a[@title = 'Входящие']");

        public YandexMessageReaderPage(IWebDriver driver)
        {
            Driver = driver;
        }

        IWebDriver Driver { get; set; }

        public IMailboxPage BackToMailbox()
        {
            Waiters.WaitUntilDisplayElement(Driver, _backToMailboxButton);
            Driver.FindElement(_backToMailboxButton).Click();
            return new YandexMailboxPage(Driver);
        }

        public IMessageReaderPage DeleteMessage()
        {
            Waiters.WaitUntilDisplayElement(Driver, _deleteButton);
            Driver.FindElement(_deleteButton).Click();
            return this;
        }

        public string GetAuthor()
        {
            Waiters.WaitUntilDisplayElement(Driver, _senderName);
            return Driver.FindElement(_senderName).Text;
        }

        public string GetAuthorEmail()
        {
            Waiters.WaitUntilDisplayElement(Driver, _senderEmail);
            return Driver.FindElement(_senderEmail).Text;
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