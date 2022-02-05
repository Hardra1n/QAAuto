using ModelNService.Model;

namespace Pages.Interfaces
{
    public interface ILoginPage
    {
        ILoginPage TypeUsername(string username);

        ILoginPage TypePassword(string password);

        IHomePage SubmitLogin();

        ILoginPage SubmitLoginWithoutSwitchToNewPage();

        IHomePage LoginAs(User user);

        string GetAlertMessageText();
    }
}
