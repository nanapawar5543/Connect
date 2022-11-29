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
    public class Users
    {
        [Key]
        public System.Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal MobileNumber { get; set; }
        public string Passwords { get; set; }
        public string EmailID { get; set; }
        public DateTime JoiningDateAndTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
