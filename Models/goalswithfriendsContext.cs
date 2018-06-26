using Microsoft.EntityFrameworkCore;

namespace goalswithfriends.Models
{
    public class goalswithfriendsContext : DbContext
    {
        public goalswithfriendsContext(DbContextOptions<goalswithfriendsContext> options) : base(options) {}

        public DbSet<Users> users { get; set; }
    }
}