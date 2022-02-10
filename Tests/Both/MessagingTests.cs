using ModelNService.Driver;
using ModelNService.Service;
using NUnit.Framework;
using OpenQA.Selenium;
using Pages;
using Pages.Interfaces;
using Pages.Mailru;
using Pages.Yandex;
using System.Threading;

namespace Tests.Both
{
    [TestFixture]
    [Category("All")]
    [Category("Smoke")]
    public class MessagingTests : BaseTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = DriverManager.GetWebDriver();
            _driver.Url = MailruLoginPage.URL;
            MailruLoginPage mailruLoginPage = new MailruLoginPage(_driver);

            mailruLoginPage.LoginAs(accounts.Mailru)
                           .GoToMailboxPage();

            _driver.Url = YandexLoginPage.URL;
            YandexLoginPage yandexLoginPage = new YandexLoginPage(_driver);

            yandexLoginPage.LoginAs(accounts.Yandex);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            DriverManager.CloseDriver();
        }

        [Test]
        public void MessageFromYandexToMailru()
        {
            string messageSubject = "YandexToMailru";
            string messageText = "This text should be checked";

            _driver.Url = YandexMailboxPage.URL;
            IMailboxPage mailboxPage = new YandexMailboxPage(_driver);
            mailboxPage.OpenMessageComposer()
                       .SendMessage(messageSubject, 
                                    messageText,
                                    accounts.Mailru.Email);

            _driver.Url = MailruLoginPage.URL;
            mailboxPage = new MailruMailboxPage(_driver);
            IMessageReaderPage readerPage 
                = mailboxPage.OpenNewMessageFromConcreteAuthor(accounts.Yandex.Username);

            Assert.AreEqual(messageText, readerPage.GetText());
            Assert.AreEqual(messageSubject, readerPage.GetSubject());
            Assert.AreEqual(accounts.Yandex.Email, readerPage.GetAuthorEmail());

            readerPage.DeleteMessage();
        }
        
        [Test]
        public void MessageFromMailruToYandex()
        {
            string messageSubject = "MailruToYandex";
            string messageText = "This text should be checked";

            _driver.Url = MailruMailboxPage.URL;
            IMailboxPage mailboxPage = new MailruMailboxPage(_driver);
            mailboxPage.OpenMessageComposer()
                       .SendMessage(messageSubject, 
                                    messageText,
                                    accounts.Yandex.Email);
            _driver.Url = YandexMailboxPage.URL;
            mailboxPage = new YandexMailboxPage(_driver);
            IMessageReaderPage readerPage 
                = mailboxPage.OpenNewMessageFromConcreteAuthor(accounts.Mailru.Username);

            Assert.AreEqual(messageText, readerPage.GetText());
            Assert.AreEqual(messageSubject, readerPage.GetSubject());
            Assert.AreEqual(accounts.Mailru.Email, readerPage.GetAuthorEmail());

            readerPage.DeleteMessage();
        }

        [Test]
        public void ChangeYandexNicknameOnMailruMessage()
        {
            string messageSubjct = "Changing nickname";
            string messageText = "Contro";

            _driver.Url = MailruMailboxPage.URL;
            IMailboxPage mailboxPage = new MailruMailboxPage(_driver);
            mailboxPage.OpenMessageComposer()
                       .SendMessage(messageSubjct, 
                                    messageText,
                                    accounts.Yandex.Email);
            _driver.Url = YandexMailboxPage.URL;
            mailboxPage = new YandexMailboxPage(_driver);
            IMessageReaderPage readerPage 
                = mailboxPage.OpenNewMessageFromConcreteAuthor(accounts.Mailru.Username);
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
