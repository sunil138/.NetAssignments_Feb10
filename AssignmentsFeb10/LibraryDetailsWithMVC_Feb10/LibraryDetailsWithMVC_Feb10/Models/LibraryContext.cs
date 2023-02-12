using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibraryDetailsWithMVC_Feb10.Models
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAuthorDetail> TAuthorDetails { get; set; } = null!;
        public virtual DbSet<TBookDetail> TBookDetails { get; set; } = null!;
        public virtual DbSet<TBorrowDetail> TBorrowDetails { get; set; } = null!;
        public virtual DbSet<TStudentDetail> TStudentDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=IN3238393W2\\SQLEXPRESS;Initial Catalog=Library;Trusted_Connection=True;");
//            } 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TAuthorDetail>(entity =>
            {
                entity.HasKey(e => e.AuthorId);

                entity.ToTable("T_AuthorDetails");

                entity.Property(e => e.AuthorId).HasColumnName("authorId");

                entity.Property(e => e.AuthorName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("authorName");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("surname");
            });

            modelBuilder.Entity<TBookDetail>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.ToTable("T_BookDetails");

                entity.Property(e => e.BookId).HasColumnName("bookId");

                entity.Property(e => e.AuthorId).HasColumnName("authorId");

                entity.Property(e => e.BookName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("bookName");

                entity.Property(e => e.BookPageCount).HasColumnName("bookPageCount");
            });

            modelBuilder.Entity<TBorrowDetail>(entity =>
            {
                entity.HasKey(e => e.BorrowId);

                entity.ToTable("T_BorrowDetails");

                entity.Property(e => e.BorrowId).HasColumnName("borrowId");

                entity.Property(e => e.BookId).HasColumnName("bookId");

                entity.Property(e => e.Broughtdate)
                    .HasColumnType("date")
                    .HasColumnName("broughtdate");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.Property(e => e.Takendate)
                    .HasColumnType("date")
                    .HasColumnName("takendate");
            });

            modelBuilder.Entity<TStudentDetail>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.ToTable("T_StudentDetails");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("surname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
