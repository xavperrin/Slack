using ApiServerSlack.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiServerSlack.Tools
{
    public interface IData
    {
        DbSet<User> Users { get; set; }
        DbSet<MessagePost> MessagePosts { get; set; }
        int SaveChanges();
    }
}