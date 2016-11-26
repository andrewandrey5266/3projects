using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public class BookService
    {
        public Book book { get; set; }

        public BookService(Book book)
        {
            this.book = book;
        }        
    }
}
