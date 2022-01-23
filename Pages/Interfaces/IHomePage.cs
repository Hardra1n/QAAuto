using Pages.Interfaces;

namespace Pages
{
    public interface IHomePage
    {
        public IMailboxPage GoToMailboxPage();

        public IHomePage ChangeNickname(string nickname);
    }
}
