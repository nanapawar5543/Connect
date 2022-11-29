using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using ViewModelLayer;
using DomainViewModel;
using System.Web.Security;

namespace Connect.APIController
{
    public class UserController : ApiController
    {   
        ConnectDBContext db = new ConnectDBContext();
        public string PostRegister(RegisterViewModel rvm)
        {
            if(ModelState.IsValid)
            {
                if(rvm.Passwords==rvm.ConfirmPassword)
                {
                    var isexist = Emailexist(rvm.EmailID);
                    if(isexist)
                    {
                        return "User already there with " + rvm.EmailID + " ";
                    }
                    else
                    {
                        Users user = new Users()
                        {
                            UserID = Guid.NewGuid(),
                            FirstName = rvm.FirstName,
                            LastName = rvm.LastName,
                            MobileNumber = rvm.MobileNumber,
                            Passwords = SHA256HashGenerator.GenerateHash(rvm.Passwords),
                            EmailID = rvm.EmailID,
                            IsActive = false,
                            IsDeleted = false,
                            JoiningDateAndTime = DateTime.Now
                        };
                        db.users.Add(user);
                        //HttpContext.Current.Session["CurrentUserID"] = rvm.UserID;
                        //HttpContext.Current.Session["CurrentUserMobile"] = rvm.MobileNumber;
                        //HttpContext.Current.Session["CurrentUserEmail"] = rvm.EmailID;
                        db.SaveChanges();
                    }
                }else
                {
                    return "Password and confirm password not matches";
                }
                return "Account Created Successfully";
            }
            else
            {
                return "Please provide all information";
            }
            
        }
        public string PutLogin(LoginViewModel lvm)
        {
                string passwordhash = SHA256HashGenerator.GenerateHash(lvm.Passwords);
                var user = db.users.Where(temp => temp.MobileNumber == lvm.MobileNumber && temp.Passwords == passwordhash).FirstOrDefault();
                if(user!=null)
                {
                    int timeout = lvm.RememberMe ? 525600 : 20;
                    var ticket = new FormsAuthenticationTicket(lvm.MobileNumber.ToString(), lvm.RememberMe, timeout);
                    string encrypted = FormsAuthentication.Encrypt(ticket);
                    var cookies = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                    cookies.Expires = DateTime.Now.AddMinutes(timeout);
                    cookies.HttpOnly = true;
                   HttpContext.Current.Response.Cookies.Add(cookies);

                //HttpContext.Current.Session["CurrentUserID"] = user.UserID;
                //HttpContext.Current.Session["CurrentUserMobile"] = lvm.MobileNumber;
                //HttpContext.Current.Session["CurrentUserEmail"] = user.EmailID;
                //Session["CurrentUserFirstName"] = user.FirstName;
                //HttpContext.Current.Session["CurrentUserLastName"] = user.LastName;

                return "";
                }
                else
                {
                    return "Mobile number or password is Incorrect";
                }
            
            
        }
        [System.Web.Http.Authorize]

        public List<Users> GetUserlist()   
        {
            var mobileno = User.Identity.Name;
            var user = db.users.Where(temp => temp.MobileNumber.ToString() != mobileno).OrderByDescending(temp => temp.JoiningDateAndTime).ToList();
            return user;
        }
        public bool Emailexist(string email)
        {
            var user = db.users.Where(temp => temp.EmailID == email).FirstOrDefault();
            if(user!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [System.Web.Http.Authorize]
        public string GetcurrentUser(string current)
        {
            var user = db.users.Where(temp => temp.MobileNumber.ToString() == User.Identity.Name).FirstOrDefault();
            string username = user.FirstName + " " + user.LastName;
            return username;
        }
    }
}
