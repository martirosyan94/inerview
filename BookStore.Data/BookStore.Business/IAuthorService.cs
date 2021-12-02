using BookStore.Business.Models;
using BookStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BookStore.Business
{
    public interface IAuthorService
    {
        void CreateAuthor(AuthorViewModel authorViewModel);
        HttpStatusCode DeleteAuthorById(Guid id);
        Task<List<Author>> GetAllAuthors();
        Task<Author> GetAuthorByName(string name);
        Task UpdateAuthor(Guid id, AuthorViewModel AuthorViewModel);
    }
}