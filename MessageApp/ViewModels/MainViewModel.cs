using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MessageApp.BusinessLogic;
using MessageApp.ViewModels.MVVM;

namespace MessageApp.ViewModels
{
    // Класс для основного окна
    public class MainViewModel: NotificationObject
    {

        #region Конструктор
        public MainViewModel()
        {

        }
        public MainViewModel(IMessageControl messageControl)
        {
            _messageControl = messageControl;
            if (_messageControl != null)
            {
                messageControl.UpdateMessagesEvent += OnUpdateMessagesEvent;
            }
            if (_messageControl != null)
            {
                CreateMessageViewModels(_messageControl.GetMessage());
            }
            
        }

        #endregion

        #region Свойства

        private readonly IMessageControl _messageControl;

        #region string NewMessage 

        private string _newMessage;

        public string NewMessage
        {
            get { return _newMessage; }
            set
            {
                if (_newMessage != value)
                {
                    _newMessage = value;
                    RaisePropertyChanged(() => NewMessage);
                }
            }
        }

        #endregion

        #region List<MessageViewModel> MessageViewModels 

        private List<MessageViewModel> _messageViewModels;

        public List<MessageViewModel> MessageViewModels
        {
            get { return _messageViewModels; }
            set
            {
                if (_messageViewModels != value)
                {
                    _messageViewModels = value;
                    RaisePropertyChanged(() => MessageViewModels);
                }
            }
        }

        #endregion

        #endregion

        #region Команды
        // Добавление нового сообщения
        #region Command AddCommand

        public ICommand AddCommand
        {
            get { return new DelegateCommand(OnAdd); }
        }

        private void OnAdd()
        {
            _messageControl?.AddMessage(NewMessage);
        }

        #endregion

        #endregion

        #region Методы

        // Обновление списка сообщений
        private void OnUpdateMessagesEvent(object sender, UpdateMessagesEventArgs e)
        {
            CreateMessageViewModels(e.MessageList);
        }

        private void CreateMessageViewModels(Dictionary<int, string> messages)
        {
            if (messages!=null)
            {
                List<MessageViewModel> messageViewModels = new List<MessageViewModel>();
                foreach (var message in messages)
                {
                    messageViewModels.Add(new MessageViewModel(_messageControl, message.Key, message.Value));
                }
                MessageViewModels = messageViewModels;
            }
        }

        #endregion
    }
}
