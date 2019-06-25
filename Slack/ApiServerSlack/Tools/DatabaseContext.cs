using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServerSlack.ClientApp.Tools
{
  public class DatabaseContext : DbContext
    {
        private static DataBaseContext _instance = null;
        private static readonly object _lock = new object();

        public static DataBaseContext Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new DataBaseContext();
                    return _instance;
                }
            }
        }
        private DataBaseContext()
        {
            RelationalDatabaseCreator creator = (RelationalDatabaseCreator)Database.GetService<IRelationalDatabaseCreator>();
            try
            {
                creator.CreateTables();
            }
            catch (Exception e)
            {

            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\DatabaseSlack;Integrated Security=True");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<MessagePost> MessagesPost { get; set; }
    }
}
