using OpenQA.Selenium;
using Pages.Interfaces;

namespace Pages.Mailru
{
    public class MailruMessageComposerPage : IMessageComposerPage
    {
        By _recipientsEmailInput = By.XPath("//div[contains(@class, 'contactsContainer')]//input");

        public MailruMessageComposerPage(IWebDriver driver)
        {
            Driver = driver;
        }

        IWebDriver Driver { get; set; }

        public IMessageComposerPage ClickSendMessageButton()
        {
            throw new System.NotImplementedException();
        }

        public IMessageComposerPage EnterRecipientEmailSendingMessage(params string[] recipients)
        {
            Waiters.WaitUntilDisplayElement(Driver, _recipientsEmailInput);
            Driver.FindElement(_recipientsEmailInput).SendKeys(recipients.ToString());
            return this;
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
