using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServerSlack.Models
{
  public class MessagePost 
  {
        [Required]
        private int id;
        private string title;
        private string content;
        private int userId;


  }
}
