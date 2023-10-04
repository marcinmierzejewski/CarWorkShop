using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarWorkShop.Infrastructure.Persistence
{
    public class CarWorkShopDbContext : IdentityDbContext
    {
        public CarWorkShopDbContext(DbContextOptions<CarWorkShopDbContext> options) : base(options)
        {

        }
        public DbSet<Domain.Entities.CarWorkShop> CarWorkshops {  get; set; }
        public DbSet<Domain.Entities.CarWorkShopService> Services {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Entities.CarWorkShop>()
                .OwnsOne(c => c.ContactDetails);

            modelBuilder.Entity<Domain.Entities.CarWorkShop>()
                .HasMany(c => c.Services)
                .WithOne(s => s.CarWorkShop)
                .HasForeignKey(s => s.CarWorkShopId);
        }
    }
}
