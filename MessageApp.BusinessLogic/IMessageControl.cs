using System;
using System.Collections.Generic;

namespace MessageApp.BusinessLogic
{
    public interface IMessageControl
    {
        Dictionary<int, string> GetMessage();
        void AddMessage(string message);
        void DeleteMessage(int id);
        event UpdateMessagesHandler UpdateMessagesEvent;
    }

    #region UpdateMessagesEvent

    public delegate void UpdateMessagesHandler(Object sender, UpdateMessagesEventArgs e);

    public class UpdateMessagesEventArgs : EventArgs
    {
        public readonly Dictionary<int,string> MessageList;

        public UpdateMessagesEventArgs(Dictionary<int, string> messageList)
        {
            MessageList = messageList;
        }
    }

    #endregion
}