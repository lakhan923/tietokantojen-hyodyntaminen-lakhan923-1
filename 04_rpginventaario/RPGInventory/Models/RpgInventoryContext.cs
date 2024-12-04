using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RPGInventory.Models;

public partial class RpgInventoryContext : DbContext
{
    public RpgInventoryContext()
    {
    }

    public RpgInventoryContext(DbContextOptions<RpgInventoryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemRarity> ItemRarities { get; set; }

    public virtual DbSet<ItemType> ItemTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=RpgInventory;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Items__3214EC0707D09437");

            entity.Property(e => e.AttValue).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.BaseValue).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DefValue).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ItemName).HasMaxLength(100);

            entity.HasOne(d => d.ItemType).WithMany(p => p.Items)
                .HasForeignKey(d => d.ItemTypeId)
                .HasConstraintName("FK__Items__ItemTypeI__4D94879B");

            entity.HasOne(d => d.Rarity).WithMany(p => p.Items)
                .HasForeignKey(d => d.RarityId)
                .HasConstraintName("FK__Items__RarityId__4E88ABD4");
        });

        modelBuilder.Entity<ItemRarity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ItemRari__3214EC07A547BDA5");

            entity.Property(e => e.RarityName).HasMaxLength(100);
        });

        modelBuilder.Entity<ItemType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ItemType__3214EC07AE60338E");

            entity.Property(e => e.TypeName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
