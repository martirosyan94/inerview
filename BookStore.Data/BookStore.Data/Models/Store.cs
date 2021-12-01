using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Models
{
    public class Store
    {
        public Guid Id { get; set; }
        public string Name { get; set; }  
        public string Address { get; set; }
        public IEnumerable<StoreBook> StoreBooks { get; set; } = new HashSet<StoreBook>();
    }
}
