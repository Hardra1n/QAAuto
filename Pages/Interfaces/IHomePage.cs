using Pages.Interfaces;

namespace Pages
{
    public interface IHomePage
    {
        public IMailboxPage GoToMailboxPage();

        public string GetNickname();

        public IHomePage ChangeNickname(string nickname);
    }
}
