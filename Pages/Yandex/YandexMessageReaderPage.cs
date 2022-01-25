using OpenQA.Selenium;
using Pages.Interfaces;

namespace Pages.Yandex
{
    public class YandexMessageReaderPage : BasePage, IMessageReaderPage
    {
        By _subjectTextLocator = By.XPath("//*[contains(@class, 'Title__subject')]");

        By _letterBodyLocator = By.XPath("//*[contains(@class, 'MessageBody__body')]/div");

        By _senderNameLocator = By.XPath("//*[contains(@class, 'SenderName')]");

        By _senderEmailLocator = By.XPath("//*[contains(@class, 'SenderEmail')]");

        By _deleteButtonLocator = By.XPath("//*[contains(@title, 'Удалить')]");

        By _backToMailboxButtonLocator = By.XPath("//a[@title = 'Входящие']");


        public YandexMessageReaderPage(IWebDriver driver) : base(driver) { }


        public IMailboxPage BackToMailbox()
        {
            Waiters.WaitUntilDisplayElement(Driver, _backToMailboxButtonLocator);
            Driver.FindElement(_backToMailboxButtonLocator).Click();
            return new YandexMailboxPage(Driver);
        }

        public IMessageReaderPage DeleteMessage()
        {
            Waiters.WaitUntilDisplayElement(Driver, _deleteButtonLocator);
            Driver.FindElement(_deleteButtonLocator).Click();
            return this;
        }

        public string GetAuthor()
        {
            Waiters.WaitUntilDisplayElement(Driver, _senderNameLocator);
            return Driver.FindElement(_senderNameLocator).Text;
        }

        public string GetAuthorEmail()
        {
            Waiters.WaitUntilDisplayElement(Driver, _senderEmailLocator);
            return Driver.FindElement(_senderEmailLocator).Text;
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