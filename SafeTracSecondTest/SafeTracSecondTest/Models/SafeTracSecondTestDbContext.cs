using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SafeTracSecondTest.Models
{
    public partial class SafeTracSecondTestDbContext : DbContext
    {
        public SafeTracSecondTestDbContext()
            : base("name=SafeTracSecondTestDbContext")
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.UserPermissions)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.User_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
