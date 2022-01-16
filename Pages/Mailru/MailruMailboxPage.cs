using OpenQA.Selenium;
using Pages.Interfaces;

namespace Pages.Mailru
{
    public class MailruMailboxPage : Page, IMailboxPage
    {
        public MailruMailboxPage(IWebDriver driver)
        {
            Driver = driver;
        }

        IWebDriver Driver { get; set; }

        public IMessageComposerPage OpenMessageComposer()
        {
            throw new System.NotImplementedException();
        }
    }
}