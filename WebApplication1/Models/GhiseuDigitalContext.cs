using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class GhiseuDigitalContext : IdentityDbContext
    {
        public GhiseuDigitalContext()
        {
        }

        public GhiseuDigitalContext(DbContextOptions<GhiseuDigitalContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        //public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        //public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        //public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        //public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        //public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        //public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Cereri> Cereri { get; set; }
        public virtual DbSet<Institutii> Institutii { get; set; }
        public virtual DbSet<Persoane> Persoane { get; set; }
        public virtual DbSet<PersoaneMedic> PersoaneMedic { get; set; }
        public virtual DbSet<PersoanePolitie> PersoanePolitie { get; set; }
        public virtual DbSet<StudentiUniversitate> StudentiUniversitate { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-L3QNDPI;Database = GhiseuDigital;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<AspNetRoleClaims>(entity =>
            //{
            //    entity.Property(e => e.RoleId)
            //        .IsRequired()
            //        .HasMaxLength(450);

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.AspNetRoleClaims)
            //        .HasForeignKey(d => d.RoleId);
            //});

            //modelBuilder.Entity<AspNetRoles>(entity =>
            //{
            //    entity.Property(e => e.Name).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedName).HasMaxLength(256);
            //});

            //modelBuilder.Entity<AspNetUserClaims>(entity =>
            //{
            //    entity.Property(e => e.UserId)
            //        .IsRequired()
            //        .HasMaxLength(450);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserClaims)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserLogins>(entity =>
            //{
            //    entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            //    entity.Property(e => e.LoginProvider).HasMaxLength(128);

            //    entity.Property(e => e.ProviderKey).HasMaxLength(128);

            //    entity.Property(e => e.UserId)
            //        .IsRequired()
            //        .HasMaxLength(450);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserLogins)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserRoles>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.RoleId });

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.AspNetUserRoles)
            //        .HasForeignKey(d => d.RoleId);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserRoles)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserTokens>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            //    entity.Property(e => e.LoginProvider).HasMaxLength(128);

            //    entity.Property(e => e.Name).HasMaxLength(128);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserTokens)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUsers>(entity =>
            //{
            //    entity.Property(e => e.Email).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

            //    entity.Property(e => e.UserName).HasMaxLength(256);
            //});

            modelBuilder.Entity<Cereri>(entity =>
            {
                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.TipCerere).HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.HasOne(d => d.Institutie)
                    .WithMany(p => p.Cereri)
                    .HasForeignKey(d => d.InstitutieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cereri_Institutii");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Cereri)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cereri_Persoane");
            });

            modelBuilder.Entity<Institutii>(entity =>
            {
                entity.Property(e => e.NumeInstitutie)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Persoane>(entity =>
            {
                entity.HasKey(e => e.Cnp);

                entity.Property(e => e.Cnp)
                    .HasColumnName("CNP")
                    .HasMaxLength(13);

                entity.Property(e => e.Adresa)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Oras)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DataNasterii).HasColumnType("date");

                entity.Property(e => e.Numar)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Nume)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Prenume)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Serie)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.StatusMedic).HasMaxLength(50);

                entity.Property(e => e.StatusPolitie).HasMaxLength(50);
            });

            modelBuilder.Entity<PersoaneMedic>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cnp)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.Nume)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Prenume)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PersoanePolitie>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cnp)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.Nume)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Prenume)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StudentiUniversitate>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.An)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cnp)
                    .IsRequired()
                    .HasColumnName("CNP")
                    .HasMaxLength(50);

                entity.Property(e => e.Facultate)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nume).HasMaxLength(50);

                entity.Property(e => e.Prenume).HasMaxLength(50);

                entity.Property(e => e.Specializare)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Stadiu)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
          
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}




