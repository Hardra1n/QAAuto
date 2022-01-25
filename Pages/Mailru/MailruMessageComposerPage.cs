using OpenQA.Selenium;
using Pages.Interfaces;

namespace Pages.Mailru
{
    public class MailruMessageComposerPage : BasePage, IMessageComposerPage
    {
        By _recipientsEmailInputLocator = By.XPath("//div[contains(@class, 'contactsContainer')]//input");

        By _subjectInputLocator = By.XPath("//input[@name = 'Subject']");

        By _textInputLocator = By.XPath("//div[@role='textbox']/div[1]");

        By _sendButtonLocator = By.XPath("//span[@title='Отправить']");

        By _backToMailboxButtonAfterSendingLocator = By.XPath("//*[@title = 'Закрыть']/span");


        public MailruMessageComposerPage(IWebDriver driver) : base(driver) { }


        public IMailboxPage BackToMailboxPageAfterSendingMessage()
        {
            Waiters.WaitUntilDisplayElement(Driver, _backToMailboxButtonAfterSendingLocator);
            Driver.FindElement(_backToMailboxButtonAfterSendingLocator).Click();
            return new MailruMailboxPage(Driver);
        }

        public IMessageComposerPage ClickSendMessageButton()
        {
            Waiters.WaitUntilDisplayElement(Driver, _sendButtonLocator);
            Driver.FindElement(_sendButtonLocator).Click();
            return this;
        }

        public IMessageComposerPage EnterRecipientEmailSendingMessage(params string[] recipients)
        {
            Waiters.WaitUntilDisplayElement(Driver, _recipientsEmailInputLocator);
            IWebElement recipientsInput = Driver.FindElement(_recipientsEmailInputLocator);
            foreach (string recipient in recipients)
            {
                recipientsInput.SendKeys(recipient + ' ');
            }
            return this;
        }

        public IMessageComposerPage EnterTextSendingMessage(string text)
        {
            Waiters.WaitUntilDisplayElement(Driver, _textInputLocator);
            Driver.FindElement(_textInputLocator).SendKeys(text);
            return this;
        }

        public IMessageComposerPage EnterTopicSendingMessage(string topic)
        {
            Waiters.WaitUntilDisplayElement(Driver, _subjectInputLocator);
            Driver.FindElement(_subjectInputLocator).SendKeys(topic);
            return this;
        }

        public IMailboxPage SendMessage(string topic, string text, params string[] recipients)
        {
            EnterRecipientEmailSendingMessage(recipients);
            EnterTopicSendingMessage(topic);
            EnterTextSendingMessage(text);
            ClickSendMessageButton();
            return BackToMailboxPageAfterSendingMessage();
        }
    }
}
