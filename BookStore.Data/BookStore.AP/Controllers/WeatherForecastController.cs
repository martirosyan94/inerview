using BookStore.Data;
using BookStore.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.AP.Controllers
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
        private readonly BookStoreDbContext context;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, BookStoreDbContext context)
        {
            _logger = logger;
            this.context = context;
        }
        [HttpPost]
        public async Task Add(Book book)
        {
            book.Created = DateTime.UtcNow;
            context.Books.Add(book);
            await context.SaveChangesAsync();
        }

        [HttpGet]
        public Task<List<Book>> GetBooks()
        {
            return context.Books.ToListAsync();
        }
    }
}
