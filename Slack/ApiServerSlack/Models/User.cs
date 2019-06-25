using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServerSlack.Models
{
  public class User 
  {
        [Required]
        private int id;
        [Required]
        private string name;
        private string token;
        private string email;
        [Required]
        private string password;
        private ICollection<Message> listMessages;

        
        string Name { get; set; }
        string Password { get; set; }
        public string Email { get => email; set => email = value; }
        ICollection<Message> ListMessages { get; set; }

    }
}
