﻿using OpenQA.Selenium;
using Pages.Interfaces;
using System.Threading;

namespace Pages.Mailru
{
    public class MailruMessageReaderPage : BasePage, IMessageReaderPage
    {
        By _backToMailboxButtonLocator = By.XPath("//a[text() = 'Почта']");

        By _deleteMessageButtonLocator = By.XPath("//*[@title = 'Удалить']");

        By _authorContactTextLocator = By.XPath("//*[contains(@class, 'letter-contact')]");

        By _subjectTextLocator = By.XPath("//*[contains(@class, 'thread-subject')]");

        By _letterBodyLocator = By.XPath("//*[@class = 'letter-body']");

        By _isInBacketTextLocator = By.XPath("//*[@class = 'notify__message__text']");


        public MailruMessageReaderPage(IWebDriver driver) : base(driver) { }


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