using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;     

namespace ViewModelLayer
{
    public class MessageViewModel
    {
        public System.Guid MessageID { get; set; }
        public System.Guid UserID { get; set; }
        public string MessageText { get; set; }
        public string MessageDateAndTime { get; set; }
        public bool IsDeleted { get; set; }
        public System.Guid SenderID { get; set; }
    }
}
