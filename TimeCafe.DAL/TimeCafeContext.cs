using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TimeCafe.DAL.Models;

namespace TimeCafe.DAL;

public partial class TimeCafeContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public TimeCafeContext()
    {
    }

    public TimeCafeContext(DbContextOptions<TimeCafeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    public virtual DbSet<TableGameReservation> TableGameReservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Game>(entity =>
        {
            entity.ToTable("Game");

            entity.Property(e => e.Id).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.ToTable("Reservation");

            entity.Property(e => e.Id).HasMaxLength(150);
            entity.Property(e => e.TableGameId).HasMaxLength(150);
            entity.Property(e => e.TimeEnd).HasColumnType("datetime");
            entity.Property(e => e.TimeStart).HasColumnType("datetime");
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.ToTable("Table");

            entity.Property(e => e.Id).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<TableGameReservation>(entity =>
        {
            entity.ToTable("TableGameReservation");

            entity.Property(e => e.Id).HasMaxLength(150);
            entity.Property(e => e.GameId).HasMaxLength(150);
            entity.Property(e => e.TableId).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
