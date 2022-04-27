using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FORFOOD.Models;
namespace FORFOOD.Data
{
    public partial class ForfoodContext : DbContext
    {
        public ForfoodContext()
        {
        }

        public ForfoodContext(DbContextOptions<ForfoodContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Products> Product { get; set; } = null!;
        public virtual DbSet<Purchases> Purchase { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UsersView> UsersViews { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=ec2-3-209-124-113.compute-1.amazonaws.com;port=5432;Username=imnanxinwbzblu;Password=c03956d7e10db9b3a8d1ea47b5564af2a6660a94545d151205dd49a50be942ef;Database=d86c1d2l7u7vc6");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("Products_pkey");

                entity.ToTable("Products", "FORFOOD");

                entity.HasIndex(e => e.Code, "Code")
                    .IsUnique();

                entity.Property(e => e.IdProduct).UseIdentityAlwaysColumn();

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.Image).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Purchases>(entity =>
            {
                entity.ToTable("Purchases", "FORFOOD");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Date).HasMaxLength(50);

            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("Role_pkey");

                entity.ToTable("Role", "FORFOOD");

                entity.Property(e => e.IdRole).UseIdentityAlwaysColumn();

                entity.Property(e => e.Name).HasMaxLength(20);
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

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Role)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pk_role");
            });

            modelBuilder.Entity<UsersView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Users_View", "FORFOOD");

                entity.Property(e => e.Email).HasMaxLength(20);

                entity.Property(e => e.Lastname).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.Rol)
                    .HasMaxLength(20)
                    .HasColumnName("rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
