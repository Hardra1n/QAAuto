using OpenQA.Selenium;
using Pages.Interfaces;

namespace Pages.Yandex
{
    public class YandexMessageComposerPage : IMessageComposerPage
    {
        By _sendButton = By.XPath("//*[text() = 'Отправить']//ancestor::button");

        By _recipientsEmailInput = By.XPath("//div[contains(@class, 'composeYabbles')]");

        By _subjectInput = By.XPath("//input[@name = 'subject']");

        By _textInput = By.XPath("//div[@role = 'textbox']/div[1]");

        public YandexMessageComposerPage(IWebDriver driver)
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

        public IMessageComposerPage SendMessage(string topic, string text,params string[] recipients)
        {
            EnterRecipientEmailSendingMessage(recipients).EnterTopicSendingMessage(topic);
            return EnterTextSendingMessage(text).ClickSendMessageButton();
        }
    }
}