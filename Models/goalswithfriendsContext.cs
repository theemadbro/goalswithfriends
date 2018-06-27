using Microsoft.EntityFrameworkCore;

namespace goalswithfriends.Models
{
    public class goalswithfriendsContext : DbContext
    {
        public goalswithfriendsContext(DbContextOptions<goalswithfriendsContext> options) : base(options) {}

        public DbSet<Users> users { get; set; }
        public DbSet<Groups> groups { get; set; }
        public DbSet<Members> members { get; set; }
        public DbSet<Goals> goals { get; set; }
    }
}