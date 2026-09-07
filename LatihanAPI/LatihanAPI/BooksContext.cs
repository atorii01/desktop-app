using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LatihanAPI;

public partial class BooksContext : DbContext
{
    public BooksContext()
    {
    }

    public BooksContext(DbContextOptions<BooksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Books");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__books__3213E83F5AE4EAAE");

            entity.ToTable("books");

            entity.Property(e => e.Id)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Author)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("author");
            entity.Property(e => e.BookTitle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("book_title");
            entity.Property(e => e.IdUser)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_user");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Publisher)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("publisher");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__books__id_user__3D5E1FD2");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__roles__3213E83FD99E33E8");

            entity.ToTable("roles");

            entity.Property(e => e.Id)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F7832AC5D");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "UQ__users__AB6E616421C32146").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.NameUser)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name_user");
            entity.Property(e => e.PasswordUser)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password_user");
            entity.Property(e => e.RolesId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("roles_id");
            entity.Property(e => e.StatusUser)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("status_user");

            entity.HasOne(d => d.Roles).WithMany(p => p.Users)
                .HasForeignKey(d => d.RolesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__users__roles_id__3A81B327");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
