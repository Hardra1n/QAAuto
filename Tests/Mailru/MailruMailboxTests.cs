using NUnit.Framework;
using OpenQA.Selenium;
using Pages.Mailru;
using System.Threading;

namespace Tests.Mailru
{
    [TestFixture]
    class MailruMailboxTests : BaseTest
    {
        MailruMailboxPage _page;

        IWebDriver _driver;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = GetNewChromeDriver();
            _driver.Url = MailruLoginPage.url;
            MailruLoginPage loginPage = new MailruLoginPage(_driver);

            _page = (MailruMailboxPage)loginPage.LoginAs(AccountCredenitals.mailruLogin,
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
            _driver.Url = "https://e.mail.ru/inbox";
        }

        [Test]
        public void CanOpenMessageComposerTest()
        {
            MailruMessageComposerPage composerPage = (MailruMessageComposerPage)_page.OpenMessageComposer();
            try
            {
                composerPage.EnterRecipientEmailSendingMessage("temp@temp");
            }
            catch (System.Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
