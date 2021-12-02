using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class BookStoreDbContext:DbContext
    {
        public BookStoreDbContext( DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<StoreBook> StoreBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasKey(e => e.Id);
            modelBuilder.Entity<Book>().HasMany(e => e.StoreBooks).WithOne(e => e.Book).HasForeignKey(e => e.BookId);
            modelBuilder.Entity<Book>().HasOne(e => e.Author).WithMany(e => e.Books).HasForeignKey(e => e.AuthorId).OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Store>().HasKey(e => e.Id);
            modelBuilder.Entity<Store>().HasMany(e => e.StoreBooks).WithOne(e => e.Store).HasForeignKey(e => e.StoreId);
            modelBuilder.Entity<StoreBook>().HasKey(e => new { e.StoreId, e.BookId });
            modelBuilder.Entity<Author>().HasKey(e => e.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
