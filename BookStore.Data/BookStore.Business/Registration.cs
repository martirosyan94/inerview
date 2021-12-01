using BookStore.Data;
using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business
{
    public class Registration : IRegistration
    {
        private readonly BookStoreDbContext context;

        public Registration(BookStoreDbContext context)
        {
            this.context = context;
        }

        public async Task RegisterBook(Book book)
        {
            book.Created = DateTime.UtcNow;
            context.Books.Add(book);
            await context.SaveChangesAsync();
        }

        public Task<List<Book>> GetBooks()
        {
            return context.Books.ToListAsync();
        }

        public BookStoreDbContext GetContext()
        {
            return context;
        }

        public async Task<Author> GetAuthorById(Guid id)
        {
            return await context.Authors.FindAsync(id);
        }

        public async Task<Author> GetAuthorByName(string name)
        {
            return await context.Authors.FirstOrDefaultAsync(e => e.Name == name);
        }
    }
}
