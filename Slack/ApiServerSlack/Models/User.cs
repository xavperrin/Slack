using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ApiServerSlack.Models
{
  public class User : IDomainObject
    {
        
        private int id;
        private string name;
        private string token;
        private string email;
        private string password;
        private ICollection<MessagePost> listMessages;


        public User()
        {
            listMessages = new List<MessagePost>();
        }

        public User(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }

        public string Email { get => email; set => email = value; }
      
        public int Id { get => id; set => id = value; }
        [Required(ErrorMessage = "Champ obligatoire"), Display(Name = "Nom de lutilisateur")]
        public string Name { get => name; set => name = value; }
        public ICollection<MessagePost> ListMessages { get => listMessages; set => listMessages = value; }
        [Required(ErrorMessage = "Champ obligatoire"), Display(Name = "mot de passe de lutilisateur")]
        public string Password { get => password; set => password = value; }
        public string Token { get => token; set => token = value; }
    }
}
