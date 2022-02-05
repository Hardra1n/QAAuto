﻿using ModelNService.Service;
using NUnit.Framework;
using OpenQA.Selenium;
using Pages.Mailru;
using System.Threading;

namespace Tests.Mailru
{
    [TestFixture]
    class MailruMailboxTests : BaseTest
    {
        private MailruMailboxPage _page;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = Driver.GetChromeDriver();
            _driver.Url = MailruLoginPage.URL;
            _page = (MailruMailboxPage)new MailruLoginPage(_driver).LoginAs(accounts.Mailru.Username,
                                                                            accounts.Mailru.Password)
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
            _driver.Url = MailruMailboxPage.URL;
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
