using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public string Title { get => title; set => title = value; }
        [Key]
        public int Id { get => id; set => id = value; }
        public string Content { get => content; set => content = value; }
        [ForeignKey("UserId")]
        public int UserId { get => userId; set => userId = value; }
        //ignore convertion en json pour eviter les objets cyclique
        [JsonIgnore]
        public User user { get; set; }
    }
}
