using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLib;

namespace BookLibConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book
            {
                Name = "Lord of Rings",
                NumOfPages = 789,
                Authors = new List<string>(new string[] { "Tolkien" }),
                Year = 1978
            };

            var bookShelfServ = new BookShelfService(new BookShelf());
            bookShelfServ.AddBook(book);
            bookShelfServ.SaveXML();
        }
    }
}
