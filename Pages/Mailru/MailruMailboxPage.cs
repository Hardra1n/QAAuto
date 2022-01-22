using OpenQA.Selenium;
using Pages.Interfaces;
using System.Threading;

namespace Pages.Mailru
{
    public class MailruMailboxPage : IMailboxPage
    {
        public static string url = "https://e.mail.ru/inbox";

        By _messageComposerButton = By.XPath("//a[contains(@class, 'compose-button')]");

        string _xpathToMessageGroup = "//div[@role = 'rowgroup']";

        public MailruMailboxPage(IWebDriver driver)
        {
            Driver = driver;
        }

        IWebDriver Driver { get; set; }

        public IMessageReaderPage OpenNewMessageFromConcreteAuthor(string author)
        {
            string xPath = _xpathToMessageGroup +
                            $"//a[" +
                            $".//*[contains(@title, '{author}')] and " +
                            $".//*[contains(@title, 'Пометить прочитанным')]]";
            By locator = By.XPath(xPath);
            Waiters.WaitUntilDisplayElement(Driver, locator);
            Driver.FindElement(locator).Click();
            return new MailruMessageReaderPage(Driver);
        }


        public IMessageComposerPage OpenMessageComposer()
        {
            Waiters.WaitUntilDisplayElement(Driver, _messageComposerButton);
            Driver.FindElement(_messageComposerButton).Click();
            return new MailruMessageComposerPage(Driver);
        }
    }
}