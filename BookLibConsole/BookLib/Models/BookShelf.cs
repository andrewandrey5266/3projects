using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public class BookShelf
    {
        public List<Book> books { get; set; }

        public BookShelf() {
            books = new List<Book>();
        }

    }
}
