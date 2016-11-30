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
        [STAThread]
        static void Main(string[] args)
        {
            #region init book and shelf

            var bookShelfServ = new BookShelfService(new BookShelf
            {
                Name = "Tolkien's books"
            });

            bookShelfServ.AddBook(new Book
            {
                Name = "Lord of Rings",
                NumOfPages = 789,
                Authors = new List<string>(new string[] { "Tolkien" }),
                Year = 1978
            });

            #endregion init book and shelf

            var session1 = new ConsoleSession(bookShelfServ);
            session1.NewSession();
           
        }
    }
    
}
