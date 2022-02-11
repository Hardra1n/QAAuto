using OpenQA.Selenium;
using Pages.Interfaces;
using System;

namespace Pages.Mailru
{
    public class MailruHomePage : BasePage, IHomePage
    {
        private By _goToMailboxButtonLocator = By.XPath("//a[text() = 'Почта'] | //a[@id = 'ph_mail']");


        public MailruHomePage(IWebDriver driver) : base(driver)
        {
            logger = NLog.LogManager.GetCurrentClassLogger();
        }


        public IMailboxPage GoToMailboxPage()
        {
            Waiters.WaitUntilDisplayElement(Driver, _goToMailboxButtonLocator);
            Driver.FindElement(_goToMailboxButtonLocator).Click();
            return new MailruMailboxPage(Driver);
        }

        public IHomePage ChangeNickname(string nickname)
        {
            throw new NotImplementedException();
        }

        public string GetNickname()
        {
            throw new NotImplementedException();
        }
    }
}
