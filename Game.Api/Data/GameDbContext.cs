using Microsoft.EntityFrameworkCore;
using System;

namespace Game.Api.Data
{
    public class GameDbContext : DbContext
    {
        public DbSet<Models.Game> Games { get; set; }

        public GameDbContext(DbContextOptions<GameDbContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Models.Game>(entity =>
            {
                entity.HasKey(m => m.Id);
                entity.Property(m => m.Name).IsRequired();
                entity.Property(m => m.State).IsRequired().HasDefaultValue(true);
                entity.Property(m => m.CreatedAt).ValueGeneratedOnAdd();
            });
        }
    }
}
