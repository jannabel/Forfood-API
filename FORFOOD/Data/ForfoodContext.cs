using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FORFOOD.Models;

namespace FORFOOD.Data
{
    public partial class ForfoodContext : DbContext
    {
        private static ForfoodContext _context = null;
        public ForfoodContext()
        {
        }

        public ForfoodContext(DbContextOptions<ForfoodContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; } 
        public virtual DbSet<Purchases> UsersProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=ec2-3-209-124-113.compute-1.amazonaws.com;port=5432;Username=imnanxinwbzblu;Password=c03956d7e10db9b3a8d1ea47b5564af2a6660a94545d151205dd49a50be942ef;Database=d86c1d2l7u7vc6;");
            }
        }

        public static ForfoodContext Create()
        {
            if(_context == null)
            {
                _context = new ForfoodContext();
            }
            return _context;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("Products_pkey");

                entity.ToTable("Products", "FORFOOD");

                entity.HasIndex(e => e.Code, "Code")
                    .IsUnique();

                entity.Property(e => e.IdProduct).ValueGeneratedNever();

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.Image).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("Users_pkey");

                entity.ToTable("Users", "FORFOOD");

                entity.Property(e => e.IdUser).UseIdentityAlwaysColumn();

                entity.Property(e => e.Email).HasMaxLength(20);

                entity.Property(e => e.Lastname).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(100);

            });

            modelBuilder.Entity<Purchases>(entity =>
            {
                entity.ToTable("Purchases", "FORFOOD");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).HasMaxLength(50);

                entity.Property(e => e.Products).HasColumnType("json");
            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
