
using Microsoft.EntityFrameworkCore;
using Final_Project.Models;

namespace Final_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts)
            : base(opts) { }

        public DbSet<GroupMember> GroupMembers => Set<GroupMember>();
        public DbSet<FavoriteMovie> FavoriteMovies => Set<FavoriteMovie>();
    }
}
