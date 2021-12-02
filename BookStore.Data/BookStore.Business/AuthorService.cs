using BookStore.Data;
using BookStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net;
using BookStore.Business.Models;
using System.Net.Http;

namespace BookStore.Business
{
    public class AuthorService : IAuthorService
    {
        private readonly BookStoreDbContext _context;

        public AuthorService(BookStoreDbContext context)
        {
            _context = context;
        }
        // Create new Author
        public void CreateAuthor(AuthorViewModel authorViewModel)
        {
            var author = new Author()
            {
                Name = authorViewModel.Name,
                Surname = authorViewModel.Surname
            };
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
        // Get Author by name
        public async Task<Author> GetAuthorByName(string name)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Name == name);
            return author;
        }
        // Get all Authors
        public Task<List<Author>> GetAllAuthors()
        {
            return _context.Authors.ToListAsync();
        }
        // Delete Author by ID
        public HttpStatusCode DeleteAuthorById(Guid id)
        {
            var author = _context.Authors.FirstOrDefault(a => a.Id == id);
            if (author == null)
                return HttpStatusCode.NotFound;

            _context.Authors.Remove(author);
            _context.SaveChanges();
            
            return HttpStatusCode.OK;
        }
        // update Author
        public async Task UpdateAuthor(Guid id, AuthorViewModel AuthorViewModel)
        {
            var existingAuthor = await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);

            existingAuthor.Name = AuthorViewModel.Name;
            existingAuthor.Surname = AuthorViewModel.Surname;

            _context.Authors.Update(existingAuthor);
            var result = await _context.SaveChangesAsync();
            Console.WriteLine(result);
        }
    }
}
