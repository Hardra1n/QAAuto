namespace Pages.Interfaces
{
    public interface IMailboxPage
    {
        IMessageComposerPage OpenMessageComposer();

        IMessageReaderPage OpenNewMessageFromConcreteAuthor(string author);

        IHomePage GoToHomePage();
    }
}