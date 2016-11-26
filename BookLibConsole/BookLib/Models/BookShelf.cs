using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public class BookShelf
    {
        public List<Book> Books { get; set; }
        public string Name { get; set; }
        public BookShelf()
        {
            Books = new List<Book>();
        }

    }
}
