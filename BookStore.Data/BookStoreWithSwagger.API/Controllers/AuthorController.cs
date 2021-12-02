using BookStore.Business;
using BookStore.Business.Models;
using BookStore.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BookStoreWithSwagger.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost("Add")]
        public void AddAuthor(AuthorViewModel authorViewModel)
        {
            _authorService.CreateAuthor(authorViewModel);   
        }

        [HttpGet("GetAll")]
        public Task<List<Author>> GetAll()
        {
           return _authorService.GetAllAuthors();
        }

        [HttpGet("GetByName")]
        public Task<Author> GetAuthorByName(string name) 
        {
            return _authorService.GetAuthorByName(name);
        }

        [HttpDelete("DelById")]
        public HttpStatusCode DeleteAuthor(Guid id) 
        {
           return _authorService.DeleteAuthorById(id);
        }

        [HttpPut("Author/Put")]
        public void PutAuthor(Guid id, AuthorViewModel authorViewModel)
        {
            _authorService.UpdateAuthor(id, authorViewModel);
        }
    }
}
