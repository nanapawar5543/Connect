using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViewModelLayer
{
    public class LoginViewModel
    {
        //[Required(ErrorMessage = "Please enter your Mobile number")]
        public decimal MobileNumber { get; set; }
        //[Required(ErrorMessage = "Please enter Password")]
        public string Passwords { get; set; }
        public bool RememberMe { get; set; }
    }
}
