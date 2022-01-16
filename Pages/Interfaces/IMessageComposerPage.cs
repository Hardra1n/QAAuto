using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.Interfaces
{
    public interface IMessageComposerPage
    {
        IMessageComposerPage SendMessage(string[] recipients, string topic, string text);

        IMessageComposerPage EnterRecipientEmailSendingMessage(string[] recipients);

        IMessageComposerPage EnterTextSendingMessage(string text);

        IMessageComposerPage EnterTopicSendingMessage(string topic);

        IMessageComposerPage ClickSendMessageButton();
    }
}
