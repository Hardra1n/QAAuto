using NUnit.Framework;
using OpenQA.Selenium;
using Pages.Mailru;
using System.Threading;

namespace Tests.Mailru
{
    [TestFixture]
    public class MailruMessageComposerTests : BaseTest
    {
        MailruMessageComposerPage _page;

        IWebDriver _driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = GetNewChromeDriver();
            _driver.Url = MailruLoginPage.url;
            MailruLoginPage loginPage = new MailruLoginPage(_driver);

            loginPage.LoginAs(AccountCredenitals.mailruLogin,
                              AccountCredenitals.mailruPassword)
                     .GoToMailboxPage();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _driver.Close();
        }

        [SetUp]
        public void SetUp()
        {
            _driver.Url = MailruMailboxPage.url;
            _page = (MailruMessageComposerPage)new MailruMailboxPage(_driver).OpenMessageComposer();
        }

        [Test]
        public void TempTest()
        {
            _page.SendMessage("SOME TOPIC", "HEY IM WRITING TO U", "kirylkho654321@yandex.ru");
            _page.BackToMailboxPageAfterSendingMessage();
        }
    }
}
