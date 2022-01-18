using OpenQA.Selenium;
using Pages.Interfaces;

namespace Pages.Mailru
{
    public class MailruMessageComposerPage : IMessageComposerPage
    {
        By _recipientsEmailInput = By.XPath("//div[contains(@class, 'contactsContainer')]//input");

        By _subjectInput = By.XPath("//input[@name = 'Subject']");

        By _textInput = By.XPath("//div[@role='textbox']/div[1]");

        By _sendButton = By.XPath("//span[@title='Отправить']");

        public MailruMessageComposerPage(IWebDriver driver)
        {
            Driver = driver;
        }

        IWebDriver Driver { get; set; }

        public IMessageComposerPage ClickSendMessageButton()
        {
            Waiters.WaitUntilDisplayElement(Driver, _sendButton);
            Driver.FindElement(_sendButton).Click();
            return this;
        }

        public IMessageComposerPage EnterRecipientEmailSendingMessage(params string[] recipients)
        {
            Waiters.WaitUntilDisplayElement(Driver, _recipientsEmailInput);
            Driver.FindElement(_recipientsEmailInput).SendKeys(recipients.ToString());
            return this;
        }

        public IMessageComposerPage EnterTextSendingMessage(string text)
        {
            Waiters.WaitUntilDisplayElement(Driver, _textInput);
            Driver.FindElement(_textInput).SendKeys(text);
            return this;
        }

        public IMessageComposerPage EnterTopicSendingMessage(string topic)
        {
            Waiters.WaitUntilDisplayElement(Driver, _subjectInput);
            Driver.FindElement(_subjectInput).SendKeys(topic);
            return this;
        }

        public IMessageComposerPage SendMessage(string topic, string text, params string[] recipients)
        {
            EnterRecipientEmailSendingMessage(recipients);
            EnterTopicSendingMessage(topic);
            EnterTextSendingMessage(text);
            ClickSendMessageButton();
            return this;
        }
    }
}
