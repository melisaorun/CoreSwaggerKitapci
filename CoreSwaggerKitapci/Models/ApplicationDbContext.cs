using Microsoft.EntityFrameworkCore;

namespace CoreSwaggerKitapci.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Kitaplar> Kitaplar { get; set; }
        public DbSet<Yazarlar> Yazarlar { get; set; }
        public DbSet<Turler> Turler { get; set; }

    }
}
