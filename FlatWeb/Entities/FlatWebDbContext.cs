using Microsoft.EntityFrameworkCore;

namespace FlatWeb.Entities
{
    public class FlatWebDbContext : DbContext
    {
        private string _connectionString = "Server=DESKTOP-AM3NPC0\\SQLEXPRESS;DataBase=FlatWeb; Trusted_Connection=True; TrustServerCertificate=True";
        public DbSet<User> Users { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
