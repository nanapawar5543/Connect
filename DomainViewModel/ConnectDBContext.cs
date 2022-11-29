using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DomainViewModel
{
    public class ConnectDBContext:DbContext
    {
        public DbSet<Users> users { get; set; }
        public DbSet<Messages> messages { get; set; }
    }
}
