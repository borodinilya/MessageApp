using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.DataBase.Model
{
    class MessageBaseContext:DbContext
    {
        public MessageBaseContext()
            : base("MessageBaseConnection")
        {
            
        }

        public DbSet<Message> Messages { get; set; }
    }
}
