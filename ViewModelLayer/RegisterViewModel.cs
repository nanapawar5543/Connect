using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViewModelLayer
{
    public class RegisterViewModel
    {
        public System.Guid UserID { get; set; }
        [Required(ErrorMessage ="Please enter your first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your Mobile number")]
        public decimal MobileNumber { get; set; }
        [Required(ErrorMessage = "Please enter Password")]
        public string Passwords { get; set; }
        [Compare("Passwords",ErrorMessage ="Password and Confirm password does not match")]
        public string ConfirmPassword { get; set; }
        [EmailAddress]
        public string EmailID { get; set; }
        public string JoiningDateAndTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}

    