using System;
using System.Collections.Generic;

namespace BookLib
{
    [Serializable]
    public class Book
    {
        public string Name { get; set; }
        public int NumOfPages { get; set; }
        public List<string> Authors { get; set; }
        public int Year { get; set; }

        public Book() : this("default1", 0, new List<string>(), 2000) { }

        public Book(string name, int numOfPages, List<string> authors, int year)
        {
            this.Name = name;
            this.NumOfPages = numOfPages;
            this.Authors = authors;
            this.Year = year;
        }       
    }
}
