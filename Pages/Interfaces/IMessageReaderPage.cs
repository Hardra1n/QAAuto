﻿namespace Pages.Interfaces
{
    public interface IMessageReaderPage
    {
        string GetAuthor();

        string GetSubject();

        string GetText();
    }
}