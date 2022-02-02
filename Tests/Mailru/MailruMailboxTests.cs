using NUnit.Framework;
using OpenQA.Selenium;
using Pages.Mailru;
using System.Threading;

namespace Tests.Mailru
{
    [TestFixture]
    class MailruMailboxTests
    {
        private MailruMailboxPage _page;

        private IWebDriver _driver;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = Driver.GetChromeDriver();
            _driver.Url = MailruLoginPage.url;
            _page = (MailruMailboxPage)new MailruLoginPage(_driver).LoginAs(AccountCredenitals.mailruLogin,
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
