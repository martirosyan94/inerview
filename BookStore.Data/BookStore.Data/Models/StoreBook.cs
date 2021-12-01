using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Models
{
    public class StoreBook
    {
        public Book Book { get; set; }
        public Store Store { get; set; }
        public Guid BookId { get; set; }
        public Guid StoreId { get; set; }
        public Decimal Price { get; set; }
    }
}
