using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Models
{
    public class Author
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Surname { get; set; }
        public IEnumerable<Book> Books { get; set; } = new HashSet<Book>();
    }
}
