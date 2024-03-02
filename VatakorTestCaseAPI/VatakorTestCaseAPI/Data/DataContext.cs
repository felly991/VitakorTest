using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VatakorTestCaseAPI.Models;

namespace VatakorTestCaseAPI.Data;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bet> Bets { get; set; }

    public virtual DbSet<Lot> Lots { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("bet_pkey");

            entity.ToTable("bet");

            entity.HasIndex(e => e.Lotid, "IX_bet_lotId");

            entity.HasIndex(e => e.Usersid, "IX_bet_usersId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Lotid).HasColumnName("lotid");
            entity.Property(e => e.Salary).HasColumnName("salary");
            entity.Property(e => e.Usersid).HasColumnName("usersid");

            entity.HasOne(d => d.Lot).WithMany(p => p.Bets)
                .HasForeignKey(d => d.Lotid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_lot");

            entity.HasOne(d => d.Users).WithMany(p => p.Bets)
                .HasForeignKey(d => d.Usersid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_users");
        });

        modelBuilder.Entity<Lot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("lot_pkey");

            entity.ToTable("lot");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Alive)
                .HasDefaultValue(true)
                .HasColumnName("alive");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("now()")
                .HasColumnName("date_created");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.StartBet)
                .HasDefaultValue(500)
                .HasColumnName("start_bet");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthday)
                .HasDefaultValueSql("now()")
                .HasColumnName("birthday");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Surname).HasColumnName("surname");

            entity.HasMany(d => d.Lots).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "Userslot",
                    r => r.HasOne<Lot>().WithMany()
                        .HasForeignKey("Lotid")
                        .HasConstraintName("fk_lot"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("Usersid")
                        .HasConstraintName("fk_users"),
                    j =>
                    {
                        j.HasKey("Usersid", "Lotid").HasName("pk_users_lot");
                        j.ToTable("userslot");
                        j.HasIndex(new[] { "Lotid" }, "IX_usersLot_lot");
                        j.HasIndex(new[] { "Usersid" }, "IX_usersLot_users");
                        j.IndexerProperty<int>("Usersid").HasColumnName("usersid");
                        j.IndexerProperty<int>("Lotid").HasColumnName("lotid");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
