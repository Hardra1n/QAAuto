using OpenQA.Selenium;
using Pages.Interfaces;
using System;

namespace Pages.Mailru
{
    public class MailruHomePage : IHomePage
    {
        public MailruHomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebDriver Driver { get; set; }

        public IMailboxPage GoToMailboxPage()
        {
            throw new NotImplementedException();
        }
    }
}
