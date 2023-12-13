using Microsoft.EntityFrameworkCore;
using PetReviewApp.Models;

namespace PetReviewApp.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<PetOwner> PetOwners { get; set; }
        public DbSet<PetCategory> PetCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PetCategory>()
                .HasKey(x => new { x.PetId, x.CategoryId });
            modelBuilder.Entity<PetCategory>()
                .HasOne(x => x.Pet)
                .WithMany(x => x.PetCategories)
                .HasForeignKey(x => x.PetId);
            modelBuilder.Entity<PetCategory>()
                .HasOne(x => x.Category)
                .WithMany(x => x.PetCategories)
                .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<PetOwner>()
                .HasKey(x => new { x.PetId, x.OwnerId });
            modelBuilder.Entity<PetOwner>()
                .HasOne(x => x.Pet)
                .WithMany(x => x.PetOwners)
                .HasForeignKey(x => x.PetId);
            modelBuilder.Entity<PetOwner>()
                .HasOne(x => x.Owner)
                .WithMany(x => x.PetOwners)
                .HasForeignKey(x => x.OwnerId);
        }
    }
}
