using MessageApp.DataBase;

namespace MessageApp.BusinessLogic
{
    public class BusinessLogicPresenter
    {
        public BusinessLogicPresenter()
        {
            DataBaseAccess dataBaseAccess = new DataBaseAccess();
            MessageControl = new MessageControl(dataBaseAccess);
        }
        public IMessageControl MessageControl { get; private set; }
    }
}