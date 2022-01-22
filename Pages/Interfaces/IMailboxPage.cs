namespace Pages.Interfaces
{
    public interface IMailboxPage
    {
        IMessageComposerPage OpenMessageComposer();

        IMessageReaderPage OpenLastMessageFromConcreteAuthor(string author);
    }
}