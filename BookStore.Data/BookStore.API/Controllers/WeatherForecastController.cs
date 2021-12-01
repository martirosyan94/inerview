using BookStore.Business;
using BookStore.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private IRegistration _registration;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRegistration registration)
        {
            _logger = logger;
            _registration = registration;
        }

        [HttpPost]
        public void Add(Book book)
        {
            _registration.RegisterBook(book);
        }

        [HttpGet]
        public Task<List<Book>> GetBooks()
        {
            return _registration.GetBooks();
        }

        [HttpGet("{id}")]
        public Task<Author> GetAuthor(Guid id)
        {
            return _registration.GetAuthorById(id);
        }
    }
}
