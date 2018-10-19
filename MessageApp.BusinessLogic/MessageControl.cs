using System.Collections.Generic;
using MessageApp.DataBase;

namespace MessageApp.BusinessLogic
{
    public class MessageControl:IMessageControl
    {

        #region Конструктор

        public MessageControl(IDataBaseAccess dataBaseAccess)
        {
            _dataBaseAccess = dataBaseAccess;
        }

        #endregion

        #region Свойства

        public event UpdateMessagesHandler UpdateMessagesEvent;

        private IDataBaseAccess _dataBaseAccess;

        #endregion

        #region Методы

        public Dictionary<int, string> GetMessage()
        {
            return _dataBaseAccess.GetMessages();
        }
        public void AddMessage(string message)
        {
            var messages = _dataBaseAccess.Add(message);
            UpdateMessagesEvent?.Invoke(this, new UpdateMessagesEventArgs(messages));
        }

        public void DeleteMessage(int id)
        {
            var messages = _dataBaseAccess.Delete(id);
            UpdateMessagesEvent?.Invoke(this, new UpdateMessagesEventArgs(messages));
        }

        #endregion
        
        

        
    }
}