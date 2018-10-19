using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.DataBase.Model
{
    class Message
    {
        [Key]
        [Column("Id")]
        public int MessageId { get; set; }
        public string Text { get; set; }
    }
}
