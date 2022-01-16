using OpenQA.Selenium;
using Pages.Interfaces;

namespace Pages.Mailru
{
    public class MailruMessageComposerPage : IMessageComposerPage
    {

        public MailruMessageComposerPage(IWebDriver driver)
        {
            Driver = driver;
        }

        IWebDriver Driver { get; set; }

        public IMessageComposerPage ClickSendMessageButton()
        {
            throw new System.NotImplementedException();
        }

        public IMessageComposerPage EnterRecipientEmailSendingMessage(string[] recipients)
        {
            throw new System.NotImplementedException();
        }

        public IMessageComposerPage EnterTextSendingMessage(string text)
        {
            throw new System.NotImplementedException();
        }

        public IMessageComposerPage EnterTopicSendingMessage(string topic)
        {
            throw new System.NotImplementedException();
        }

        public IMessageComposerPage SendMessage(string[] recipients, string topic, string text)
        {
            throw new System.NotImplementedException();
        }
    }
}
