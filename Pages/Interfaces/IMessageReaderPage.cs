namespace Pages.Interfaces
{
    public interface IMessageReaderPage
    {
        string GetAuthor();

        string GetAuthorEmail();

        string GetSubject();

        string GetText();

        IMailboxPage BackToMailbox();

        IMessageReaderPage DeleteMessage();
    }
}