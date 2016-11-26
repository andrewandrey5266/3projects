using System;
using System.Collections.Generic;

namespace BookLib
{
    [Serializable] 
    public class BookShelf
    {
        public List<Book> Books { get; set; }
        public string Name { get; set; }

        public BookShelf() : this("default1") { }

        public BookShelf(string Name)
        {
            this.Name = Name;
            Books = new List<Book>();
        }
    }
}
