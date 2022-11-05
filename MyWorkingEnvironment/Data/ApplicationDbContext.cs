using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MyWorkingEnvironment.Models.DBObjects;

namespace MyWorkingEnvironment.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Clocking> Clockings { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<MeetingRoom> MeetingRooms { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<ReservationMeetingRoom> ReservationMeetingRooms { get; set; } = null!;
        public virtual DbSet<TaskEmployee> TaskEmployees { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-CL8801R;Database=MyWorkingEnvironmentDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Clocking>(entity =>
            {
                entity.HasKey(e => e.IdClocking)
                    .HasName("PK__Clocking__99259B71D78B43C5");

                entity.ToTable("Clocking");

                entity.Property(e => e.IdClocking).ValueGeneratedNever();

                entity.Property(e => e.CheckIn).HasColumnType("datetime");

                entity.Property(e => e.CheckOut).HasColumnType("datetime");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Clockings)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clocking_Employee");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("PK__Employee__51C8DD7AFAFFF135");

                entity.ToTable("Employee");

                entity.Property(e => e.IdEmployee).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.IdReservationNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdReservation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Reservation");
            });

            modelBuilder.Entity<MeetingRoom>(entity =>
            {
                entity.HasKey(e => e.IdMeetingRoom)
                    .HasName("PK__MeetingR__62B0DD6E2522BE49");

                entity.ToTable("MeetingRoom");

                entity.Property(e => e.IdMeetingRoom).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.IdReservation)
                    .HasName("PK__Reservat__7E69A57B8AF9A54E");

                entity.ToTable("Reservation");

                entity.Property(e => e.IdReservation).ValueGeneratedNever();

                entity.Property(e => e.CheckIn).HasColumnType("datetime");

                entity.Property(e => e.CheckOut).HasColumnType("datetime");
            });

            modelBuilder.Entity<ReservationMeetingRoom>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ReservationMeetingRoom");

                entity.HasOne(d => d.IdMeetingRoomNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdMeetingRoom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReservationMeetingRoom_MeetingRoom");

                entity.HasOne(d => d.IdReservationNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdReservation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReservationMeetingRoom_Reservation");
            });

            modelBuilder.Entity<TaskEmployee>(entity =>
            {
                entity.HasKey(e => e.IdTask)
                    .HasName("PK__TaskEmpl__9FCAD1C52C5FFA95");

                entity.ToTable("TaskEmployee");

                entity.Property(e => e.IdTask).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Priority)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
