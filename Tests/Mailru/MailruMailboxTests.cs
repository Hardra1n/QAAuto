using ModelNService.Driver;
using ModelNService.Service;
using NUnit.Framework;
using OpenQA.Selenium;
using Pages.Mailru;
using System;
using System.Threading;

namespace Tests.Mailru
{
    [TestFixture]
    [Category("All")]
    class MailruMailboxTests : BaseTest
    {
        private MailruMailboxPage _page;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = DriverManager.GetWebDriver();
            _driver.Url = MailruLoginPage.URL;
            _page = (MailruMailboxPage)new MailruLoginPage(_driver).LoginAs(accounts.Mailru)
                                                                   .GoToMailboxPage();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            DriverManager.CloseDriver();
        }

        [SetUp]
        public void SetUp()
        {
            _driver.Url = MailruMailboxPage.URL;
        }

        [TearDown]
        public void TearDown()
        {
            HandleTestFailure();
        }

        [Test]
        public void CanOpenMessageComposerTest()
        {
            try
            {
                MailruMessageComposerPage composerPage = (MailruMessageComposerPage)_page.OpenMessageComposer();
                composerPage.EnterRecipientEmailSendingMessage("temp@temp");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message + '\n' + ex.StackTrace);
            }
        }
    }
}
