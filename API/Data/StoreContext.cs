using API.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class StoreContext : IdentityDbContext<User, UserRole, int>
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Entry> Entries { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;


    }
}