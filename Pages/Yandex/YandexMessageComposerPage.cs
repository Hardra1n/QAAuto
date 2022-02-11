using OpenQA.Selenium;
using Pages.Interfaces;
using Pages.Mailru;

namespace Pages.Yandex
{
    public class YandexMessageComposerPage : BasePage, IMessageComposerPage
    {
        private By _sendButtonLocator = By.XPath("//*[text() = 'Отправить']//ancestor::button");

        private By _recipientsEmailInputLocator = By.XPath("//div[contains(@class, 'composeYabbles')]");

        private By _subjectInputLocator = By.XPath("//input[@name = 'subject']");

        private By _textInputLocator = By.XPath("//div[@role = 'textbox']/div[1]");

        private By _backToMailboxButtonAfterSendingLocator = By.XPath("//a[contains(text(), 'Вернуться')]");


        public YandexMessageComposerPage(IWebDriver driver) : base(driver)
        {
            logger = NLog.LogManager.GetCurrentClassLogger();
        }


        public IMailboxPage BackToMailboxPageAfterSendingMessage()
        {
            Waiters.WaitUntilDisplayElement(Driver, _backToMailboxButtonAfterSendingLocator);
            Driver.FindElement(_backToMailboxButtonAfterSendingLocator).Click();

            logger.Info("Yandex user sent a message.");
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
            => EnterRecipientEmailSendingMessage(recipients).EnterTopicSendingMessage(topic)
                                                            .EnterTextSendingMessage(text)
                                                            .ClickSendMessageButton()
                                                            .BackToMailboxPageAfterSendingMessage();
    }
}