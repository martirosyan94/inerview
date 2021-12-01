using BookStore.Data;
using BookStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Business
{
    public interface IRegistration
    {
        Task<Author> GetAuthorById(Guid id);
        Task<Author> GetAuthorByName(string name);
        Task<List<Book>> GetBooks();
        BookStoreDbContext GetContext();
        Task RegisterBook(Book book);
    }
}