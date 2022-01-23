using OpenQA.Selenium;
using Pages.Interfaces;
using System;

namespace Pages.Mailru
{
    public class MailruHomePage : IHomePage
    {
        By _goToMailboxButton = By.XPath("//a[text() = 'Почта'] | //a[@id = 'ph_mail']");

        public MailruHomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebDriver Driver { get; set; }

        public IHomePage ChangeNickname(string nickname)
        {
            throw new NotImplementedException();
        }

        public IMailboxPage GoToMailboxPage()
        {
            Waiters.WaitUntilDisplayElement(Driver, _goToMailboxButton);
            Driver.FindElement(_goToMailboxButton).Click();
            return new MailruMailboxPage(Driver);
        }
    }
}
