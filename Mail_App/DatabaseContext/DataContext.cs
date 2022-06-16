using Mail_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Mail_App.DatabaseContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<UserProfile> User { get; set; }
        public DbSet<UserPassword> UserPassword { get; set; }
        public DbSet<OnetoOneMail> OnetoOneMails { get; set; }
    }
}
