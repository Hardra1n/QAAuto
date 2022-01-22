using OpenQA.Selenium;
using Pages.Interfaces;
using Pages.Mailru;

namespace Pages.Yandex
{
    public class YandexMessageComposerPage : IMessageComposerPage
    {
        By _sendButton = By.XPath("//*[text() = 'Отправить']//ancestor::button");

        By _recipientsEmailInput = By.XPath("//div[contains(@class, 'composeYabbles')]");

        By _subjectInput = By.XPath("//input[@name = 'subject']");

        By _textInput = By.XPath("//div[@role = 'textbox']/div[1]");

        By _backToMailboxButtonAfterSending = By.XPath("//a[contains(text(), 'Вернуться')]");

        public YandexMessageComposerPage(IWebDriver driver)
        {
            Driver = driver;
        }

        IWebDriver Driver { get; set; }

        public IMailboxPage BackToMailboxPageAfterSendingMessage()
        {
            Waiters.WaitUntilDisplayElement(Driver, _backToMailboxButtonAfterSending);
            Driver.FindElement(_backToMailboxButtonAfterSending).Click();
            return new MailruMailboxPage(Driver);
        }

        public IMessageComposerPage ClickSendMessageButton()
        {
            Waiters.WaitUntilDisplayElement(Driver, _sendButton);
            Driver.FindElement(_sendButton).Click();
            return this;
        }

        public IMessageComposerPage EnterRecipientEmailSendingMessage(params string[] recipients)
        {
            Waiters.WaitUntilDisplayElement(Driver, _recipientsEmailInput);
            IWebElement recipientsInput = Driver.FindElement(_recipientsEmailInput);
            foreach(string recipient in recipients)
            {
                recipientsInput.SendKeys(recipient + ' ');
            }
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