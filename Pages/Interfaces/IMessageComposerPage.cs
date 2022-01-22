﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.Interfaces
{
    public interface IMessageComposerPage
    {
        IMailboxPage SendMessage(string topic, string text, params string[] recipients);

        IMessageComposerPage EnterRecipientEmailSendingMessage(params string[] recipients);

        IMessageComposerPage EnterTextSendingMessage(string text);

        IMessageComposerPage EnterTopicSendingMessage(string topic);

        IMessageComposerPage ClickSendMessageButton();

        IMailboxPage BackToMailboxPageAfterSendingMessage();
    }
}
