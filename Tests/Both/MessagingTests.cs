using NUnit.Framework;
using OpenQA.Selenium;
using Pages;
using Pages.Interfaces;
using Pages.Mailru;
using Pages.Yandex;

namespace Tests.Both
{
    [TestFixture]
    public class MessagingTests : BaseTest
    {
        IWebDriver _driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = GetNewChromeDriver();
            _driver.Url = MailruLoginPage.url;
            MailruLoginPage mailruLoginPage = new MailruLoginPage(_driver);

            mailruLoginPage.LoginAs(AccountCredenitals.mailruLogin,
                                    AccountCredenitals.mailruPassword)
                           .GoToMailboxPage();

            _driver.Url = YandexLoginPage.url;
            YandexLoginPage yandexLoginPage = new YandexLoginPage(_driver);

            yandexLoginPage.LoginAs(AccountCredenitals.yandexLogin,
                                    AccountCredenitals.yandexPassword);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _driver.Close();
        }

        [Test]
        public void MessageFromYandexToMailru()
        {
            string messageSubject = "YandexToMailru";
            string messageText = "This text should be checked";

            _driver.Url = YandexMailboxPage.url;
            IMailboxPage mailboxPage = new YandexMailboxPage(_driver);
            mailboxPage.OpenMessageComposer().SendMessage(messageSubject, messageText, AccountCredenitals.mailruEmail);
            _driver.Url = MailruLoginPage.url;
            mailboxPage = new MailruMailboxPage(_driver);
            IMessageReaderPage readerPage = mailboxPage.OpenNewMessageFromConcreteAuthor(AccountCredenitals.yandexLogin);

            Assert.AreEqual(messageText, readerPage.GetText());
            Assert.AreEqual(messageSubject, readerPage.GetSubject());
            Assert.AreEqual(AccountCredenitals.yandexEmail, readerPage.GetAuthorEmail());

            readerPage.DeleteMessage();
        }
        
        [Test]
        public void MessageFromMailruToYandex()
        {
            string messageSubject = "MailruToYandex";
            string messageText = "This text should be checked";

            _driver.Url = MailruMailboxPage.url;
            IMailboxPage mailboxPage = new MailruMailboxPage(_driver);
            mailboxPage.OpenMessageComposer().SendMessage(messageSubject, messageText, AccountCredenitals.yandexEmail);
            _driver.Url = YandexMailboxPage.url;
            mailboxPage = new YandexMailboxPage(_driver);
            IMessageReaderPage readerPage = mailboxPage.OpenNewMessageFromConcreteAuthor(AccountCredenitals.mailruLogin);

            Assert.AreEqual(messageText, readerPage.GetText());
            Assert.AreEqual(messageSubject, readerPage.GetSubject());
            Assert.AreEqual(AccountCredenitals.mailruEmail, readerPage.GetAuthorEmail());

            readerPage.DeleteMessage();
        }

        [Test]
        public void ChangeYandexNicknameOnMailruMessage()
        {
            string messageSubjct = "Changing nickname";
            string messageText = "Contro";

            _driver.Url = MailruMailboxPage.url;
            IMailboxPage mailboxPage = new MailruMailboxPage(_driver);
            mailboxPage.OpenMessageComposer().SendMessage(messageSubjct, messageText, AccountCredenitals.yandexEmail);
            _driver.Url = YandexMailboxPage.url;
            mailboxPage = new YandexMailboxPage(_driver);
            IMessageReaderPage readerPage = mailboxPage.OpenNewMessageFromConcreteAuthor(AccountCredenitals.mailruLogin);
            string actualRecivedNickname = readerPage.GetText();

            Assert.AreEqual(messageText, actualRecivedNickname);

            IHomePage homePage = readerPage.DeleteMessage().BackToMailbox().GoToHomePage();
            string defaultNickame = homePage.GetNickname();
            homePage.ChangeNickname(actualRecivedNickname);
            string actualChangedNickname = homePage.GetNickname();

            Assert.AreEqual(actualRecivedNickname, actualChangedNickname);

            homePage.ChangeNickname(defaultNickame);

        }
    }
}
