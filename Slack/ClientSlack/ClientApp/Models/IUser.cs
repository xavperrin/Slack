using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientSlack.ClientApp.Models
{
  interface IUser
  {
        private string name;
        private string password;
        private ICollection<IMessage> listMessages;

        string Name { get; set; }
        string Password { get; set; }
        ICollection<IMessage> ListMessages { get; set; }
    }
}
