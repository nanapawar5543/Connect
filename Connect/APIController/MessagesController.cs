using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DomainViewModel;

namespace Connect.APIController
{
    [System.Web.Http.Authorize]
    public class MessagesController : ApiController
    {
        ConnectDBContext db = new ConnectDBContext();
        
        public Users GetUserID(decimal id)
        {
            var user = db.users.Where(temp => temp.MobileNumber == id).FirstOrDefault();
            return user;
        }
        public List<Messages> GetMessages(Guid? senderid)
        {
            var user = db.users.Where(temp => temp.MobileNumber.ToString() == User.Identity.Name).FirstOrDefault();
            
            var messages = db.messages.Where(temp => (temp.UserID == user.UserID||temp.UserID==senderid) && (temp.SenderID== senderid||temp.SenderID==user.UserID)).OrderBy(temp => temp.MessageDateAndTime).ToList();
            return messages;
        }
        public string PostMessages(Messages m)
        {
            if(m.MessageText!=null)
            {
                m.MessageID = Guid.NewGuid();
                var user = db.users.Where(temp => temp.MobileNumber.ToString() == User.Identity.Name).FirstOrDefault();
                m.UserID = user.UserID;
                m.MessageDateAndTime = DateTime.Now.ToString();
                m.IsDeleted = false;    
                db.messages.Add(m);
                db.SaveChanges();
                return "";
            }else
            {
                return "Please enter massage";
            }
            

            
        }
    }
}
