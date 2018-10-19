using System;
using System.Collections.Generic;
using System.Linq;
using MessageApp.DataBase.Model;

namespace MessageApp.DataBase
{
    public class DataBaseAccess:IDataBaseAccess
    {
        public Dictionary<int, string> Add(string message)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            try
            {
                using (MessageBaseContext context = new MessageBaseContext())
                {
                    context.Messages.Add(new Message {Text = message});
                    context.SaveChanges();
                    result = Messages(context);
                }
            }
            catch (Exception e)
            {
                Warning.Warning.Show("Не удалось вставить в БД.");
            }
            return result;
            
        }
        public Dictionary<int, string> Delete(int id)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            try
            {
                using (MessageBaseContext context = new MessageBaseContext())
                {
                    context.Messages.RemoveRange(context.Messages.Where(m => m.MessageId == id));
                    context.SaveChanges();
                    result = Messages(context);
                }
            }
            catch (Exception e)
            {
                Warning.Warning.Show("Не удалось удалить из БД.");
            }
            return result;
        }
        public Dictionary<int, string> GetMessages()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            try
            {
                using (MessageBaseContext context = new MessageBaseContext())
                {
                    result = Messages(context);
                }
            }
            catch (Exception e)
            {
                Warning.Warning.Show("Не удалось считать из БД.");
            }
            
            
            return result;
        }
        
        private Dictionary<int, string> Messages(MessageBaseContext context)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            foreach (Message message in context.Messages)
            {
                result.Add(message.MessageId, message.Text);
            }
            return result;
        }
    }
}