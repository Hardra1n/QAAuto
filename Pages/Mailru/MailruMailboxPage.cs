using OpenQA.Selenium;
using Pages.Interfaces;

namespace Pages.Mailru
{
    public class MailruMailboxPage : Page, IMailboxPage
    {
        public static string Url = "https://e.mail.ru/inbox";

        By _messageComposerButton = By.XPath("//a[contains(@class, 'compose-button')]");

        public MailruMailboxPage(IWebDriver driver)
        {
            Driver = driver;
        }

        IWebDriver Driver { get; set; }

        public IMessageComposerPage OpenMessageComposer()
        {
            Waiters.WaitUntilDisplayElement(Driver, _messageComposerButton);
            Driver.FindElement(_messageComposerButton).Click();
            return new MailruMessageComposerPage(Driver);
        }
    }
}