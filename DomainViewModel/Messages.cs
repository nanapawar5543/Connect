using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainViewModel
{
    public class Messages
    {
        [Key]
        public System.Guid MessageID { get; set; }
        public System.Guid UserID { get; set; }
        public string MessageText { get; set; }
        public string MessageDateAndTime { get; set; }
        public bool IsDeleted { get; set; }
        public System.Guid SenderID { get; set; }

        public virtual Users users { get; set; }
    }
}
