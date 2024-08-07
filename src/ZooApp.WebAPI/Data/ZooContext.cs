using Microsoft.EntityFrameworkCore;
using ZooApp.WebAPI.Data.Model;

namespace ZooApp.WebAPI.Data
{
    public class ZooContext: DbContext
    {
        public ZooContext(DbContextOptions<ZooContext> options): base(options) { }

        public DbSet<AnimalModel> Animals { get; set; }
        public DbSet<GuestModel> Guests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AnimalModel>(entity => {
                entity.ToTable("Animals");
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<GuestModel>(entity => {
                entity.ToTable("Guests");
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
            });
        }
    }
}