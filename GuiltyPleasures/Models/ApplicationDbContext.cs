
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace GuiltyPleasures.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<UserWithGoal> UsersWithGoals { get; set; }

        public DbSet<Fruit> Fruits { get; set; }
        //public DbSet<FoodTypes> FoodTypes { get; set; }

        public DbSet<UsersFruits> UsersFruits { get; set; }
        public DbSet<UsersBurns> UsersBurns { get; set; }

        public DbSet<Burn> Burns { get; set; }
        //public DbSet<Money> Money { get; set; }

        public DbSet<Package> Packages { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fruit>().ToTable("Food");
            modelBuilder.Entity<UsersBurns>().ToTable("UsersExercise");
            modelBuilder.Entity<Burn>().ToTable("Exercise");
            modelBuilder.Entity<Money>().ToTable("UsersBalance");
            modelBuilder.Entity<UserWithGoal>().ToTable("UsersGoals");

            base.OnModelCreating(modelBuilder);
        }
    }
}