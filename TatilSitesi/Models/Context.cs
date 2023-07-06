using Microsoft.EntityFrameworkCore;

namespace TatilSitesi.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-EVJH8OQ;database=TatilSiteDB;integrated security=true");
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<DestinationDetail> DestinationsDetails { get; set; }
        public DbSet<DestinationImage> DestinationsImages { get; set; }

    }
}
