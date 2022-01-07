namespace Pages
{
    public interface ILoginPage
    {
        ILoginPage TypeUsername(string username);

        ILoginPage TypePassword(string password);

        IHomePage SubmitLogin();

        ILoginPage SubmitLoginWithoutSwitchToNewPage();

        IHomePage LoginAs(string username, string password);
    }
}
