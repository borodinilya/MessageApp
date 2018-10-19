using System.Collections.Generic;
using System.Windows.Input;
using MessageApp.BusinessLogic;
using MessageApp.ViewModels.MVVM;

namespace MessageApp.ViewModels
{
    public class MessageViewModel:NotificationObject
    {
        #region Конструктор
        public MessageViewModel(IMessageControl messageControl, int id, string message)
        {
            _id = id;
            _messageControl = messageControl;
            Message = message;
        }
        #endregion

        #region Свойства

        private int _id;
        private IMessageControl _messageControl;

        #region string Message 

        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    RaisePropertyChanged(() => Message);
                }
            }
        }

        #endregion
        
        #endregion

        #region Команды
        // Удаление строки
        #region Command DeleteCommand

        public ICommand DeleteCommand
        {
            get { return new DelegateCommand(OnDelete); }
        }

        private void OnDelete()
        {
            _messageControl?.DeleteMessage(_id);
        }

        #endregion
        
        #endregion

    }
}