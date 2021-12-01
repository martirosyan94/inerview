using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public DateTime Created { get; set; }
        public int Ammount { get; set; }
        public IEnumerable<StoreBook> StoreBooks { get; set; } = new HashSet<StoreBook>();

    }
}
