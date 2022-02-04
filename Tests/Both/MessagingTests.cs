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
    public class MessagingTests
    {
        private IWebDriver _driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = Driver.GetChromeDriver();
            _driver.Url = MailruLoginPage.URL;
            MailruLoginPage mailruLoginPage = new MailruLoginPage(_driver);

            mailruLoginPage.LoginAs(AccountProvider.GetUsername("Mailru"),
                                    AccountProvider.GetPassword("Mailru"))
                           .GoToMailboxPage();

            _driver.Url = YandexLoginPage.URL;
            YandexLoginPage yandexLoginPage = new YandexLoginPage(_driver);

            yandexLoginPage.LoginAs(AccountProvider.GetUsername("Yandex"),
                                    AccountProvider.GetPassword("Yandex"));
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

            _driver.Url = YandexMailboxPage.URL;
            IMailboxPage mailboxPage = new YandexMailboxPage(_driver);
            mailboxPage.OpenMessageComposer()
                       .SendMessage(messageSubject, 
                                    messageText,
                                    AccountProvider.GetEmail("Mailru"));

            _driver.Url = MailruLoginPage.URL;
            mailboxPage = new MailruMailboxPage(_driver);
            IMessageReaderPage readerPage 
                = mailboxPage.OpenNewMessageFromConcreteAuthor(AccountProvider.GetUsername("Yandex"));

            Assert.AreEqual(messageText, readerPage.GetText());
            Assert.AreEqual(messageSubject, readerPage.GetSubject());
            Assert.AreEqual(AccountProvider.GetEmail("Yandex"), readerPage.GetAuthorEmail());

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
                                    AccountProvider.GetEmail("Yandex"));
            _driver.Url = YandexMailboxPage.URL;
            mailboxPage = new YandexMailboxPage(_driver);
            IMessageReaderPage readerPage 
                = mailboxPage.OpenNewMessageFromConcreteAuthor(AccountProvider.GetUsername("Mailru"));

            Assert.AreEqual(messageText, readerPage.GetText());
            Assert.AreEqual(messageSubject, readerPage.GetSubject());
            Assert.AreEqual(AccountProvider.GetEmail("Mailru"), readerPage.GetAuthorEmail());

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
                                    AccountProvider.GetEmail("Yandex"));
            _driver.Url = YandexMailboxPage.URL;
            mailboxPage = new YandexMailboxPage(_driver);
            IMessageReaderPage readerPage 
                = mailboxPage.OpenNewMessageFromConcreteAuthor(AccountProvider.GetUsername("Mailru"));
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
