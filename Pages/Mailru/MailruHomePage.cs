using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.Mailru
{
    public class MailruHomePage : IHomePage
    {
        public MailruHomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebDriver Driver { get; set; }

        public IHomePage GoToMailboxPage()
        {
            throw new NotImplementedException();
        }
    }
}
