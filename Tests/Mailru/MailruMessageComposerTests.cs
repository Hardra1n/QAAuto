using NUnit.Framework;
using OpenQA.Selenium;
using Pages.Mailru;

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
            MailruLoginPage loginPage = new MailruLoginPage(_driver);

            _page = (MailruMessageComposerPage)loginPage.LoginAs(AccountCredenitals.mailruLogin,
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
            _page = (MailruMessageComposerPage)new MailruMailboxPage(_driver).OpenMessageComposer();
        }
    }
}
