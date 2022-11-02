using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyWorkingEnvironment.Models.DBObbjects
{
    public partial class MyWorkingEnvironmentDBContext : DbContext
    {
        public MyWorkingEnvironmentDBContext()
        {
        }

        public MyWorkingEnvironmentDBContext(DbContextOptions<MyWorkingEnvironmentDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clocking> Clockings { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<MeetingRoom> MeetingRooms { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<ReservationMeetingRoom> ReservationMeetingRooms { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;

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

                entity.HasOne(d => d.IdTaskNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdTask)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Task");
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

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasKey(e => e.IdTask)
                    .HasName("PK__Task__9FCAD1C53994344B");

                entity.ToTable("Task");

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
