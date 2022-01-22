using OpenQA.Selenium;
using Pages.Interfaces;

namespace Pages.Mailru
{
    public class MailruMessageReaderPage : IMessageReaderPage
    {
        public MailruMessageReaderPage(IWebDriver driver)
        {
            Driver = driver;
        }

        IWebDriver Driver { get; set; }

        public IMailboxPage CloseMessage()
        {
            throw new System.NotImplementedException();
        }

        public IMailboxPage DeleteMessage()
        {
            throw new System.NotImplementedException();
        }

        public string GetAuthor()
        {
            throw new System.NotImplementedException();
        }

        public string GetSubject()
        {
            throw new System.NotImplementedException();
        }

        public string GetText()
        {
            throw new System.NotImplementedException();
        }
    }
}