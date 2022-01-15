using NUnit.Framework;
using OpenQA.Selenium;
using Pages.Yandex;

namespace Tests.Yandex
{
    [TestFixture]
    public class YandexLoginPageTests : BaseTest
    {
        private YandexLoginPage _page;

        private string _correctUsername = "kirylkho123456";

        private string _correctPassword = "Qwerty1231";

        IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = GetNewChromeDriver();
            _driver.Url = "https://passport.yandex.by/";
            _page = new YandexLoginPage(_driver);
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Close();
        }

        [Test]
        public void CannotLoginWithInccorrectUsername()
        {
            string incorrectUsername = "12342321";
            string expectedAlertMessage = "Такой логин не подойдет";
            
            _page.TypeUsername(incorrectUsername);
            _page.SubmitLoginWithoutSwitchToNewPage();
            string actualAlertMessage = _page.GetAlertMessageText();

            Assert.AreEqual(expectedAlertMessage, actualAlertMessage);
        }

        [Test]
        public void CannotLoginWithNotFoundUsername()
        {
            string notfoundUsername = "dsamksaldwasfwas";
            string expectedAlertMessage = "Такого аккаунта нет";

            _page.TypeUsername(notfoundUsername);
            _page.SubmitLoginWithoutSwitchToNewPage();
            string actualAlertMessage = _page.GetAlertMessageText();

            Assert.AreEqual(expectedAlertMessage, actualAlertMessage);
        }

        [Test]
        public void CannotLoginWithIncorrectPassword()
        {
            string incorrectPassword = "1234564321";
            string expectedAlertMessage = "Неверный пароль";

            _page.TypeUsername(_correctUsername);
            _page.SubmitLoginWithoutSwitchToNewPage();
            _page.TypePassword(incorrectPassword);
            _page.SubmitLoginWithoutSwitchToNewPage();
            string actualAlertMessage = _page.GetAlertMessageText();

            Assert.AreEqual(expectedAlertMessage, actualAlertMessage);
        }

        [Test]
        public void CannotLoginWithEmptyUsername()
        {
            string emptyUsername = string.Empty;
            string expectedAlertMessage = "Логин не указан";

            _page.TypeUsername(emptyUsername);
            _page.SubmitLoginWithoutSwitchToNewPage();
            string actualAlertMessage = _page.GetAlertMessageText();
            Assert.AreEqual(expectedAlertMessage, actualAlertMessage);
        }

        [Test]
        public void CannotLoginWithEmptyPassword()
        {
            string emptyPassword = string.Empty;
            string expectedAlertMessage = "Пароль не указан";

            _page.TypeUsername(_correctUsername);
            _page.SubmitLoginWithoutSwitchToNewPage();
            _page.TypePassword(emptyPassword);
            _page.SubmitLoginWithoutSwitchToNewPage();
            string actualAlertMessage = _page.GetAlertMessageText();

            Assert.AreEqual(expectedAlertMessage, actualAlertMessage);
        }

        [Test]
        public void LoginWithCorrectUsernameAndPassword()
        {
            string expectedDriverTitle = "Яндекс ID";

            _page.LoginAs(_correctUsername, _correctPassword);

            Assert.AreEqual(expectedDriverTitle, _driver.Title);
        }

    }
}
