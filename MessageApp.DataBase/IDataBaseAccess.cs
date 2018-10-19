using System.Collections.Generic;

namespace MessageApp.DataBase
{
    public interface IDataBaseAccess
    {
        Dictionary<int, string> Add(string message);
        Dictionary<int, string> Delete(int id);
        Dictionary<int, string> GetMessages();
    }
}