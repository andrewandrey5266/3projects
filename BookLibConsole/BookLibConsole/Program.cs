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
    class ConsoleSession
    {
        public BookShelfService shelfService;
        public ConsoleSession(BookShelfService shelfService)
        {
            this.shelfService = shelfService;
        }

        public void NewSession()
        {
            Console.WriteLine("Would you like to load new book?\n1 - Yes\n2 - No");
            if(int.Parse(Console.ReadLine()) == 1)
                shelfService.ReadXMLHelp();

            DoIteration();       
        }
        private void DoIteration()
        {
            Console.WriteLine("\n     ---------------     ");
            Console.WriteLine(
                "shelf : {0}\n1 - Get List Of Books\n2 - Add book\n3 - Delete book\n4 - End session",
                shelfService.bookShelf.Name);

            int response = int.Parse(Console.ReadLine());

            if (response == 1)
            {
                foreach (var c in shelfService.GetBooks())
                    Console.WriteLine("Title: {0}, Authors : {1}", c.Name, string.Join(" ", c.Authors));

                //- make loop
                DoIteration();               
                //
            }
            if (response == 2)
            {
                AddBook();

                //- make loop
                DoIteration();
                //
            }
            if (response == 3)
            {
                Console.WriteLine("Input book name please");
                string bookName = Console.ReadLine();
                RemoveBook(bookName);

                //- make loop
                DoIteration();
                //
            }
            if (response == 4)
            {
                EndSession();
            }
        }

        private void AddBook()
        {
            var book = new Book();

            Console.WriteLine("Input title, please");
            book.Name = Console.ReadLine();

            Console.WriteLine("Input num of pages, please");
            book.NumOfPages = int.Parse(Console.ReadLine());

            Console.WriteLine("Input list of authors through coma, please");
            book.Authors = Console.ReadLine().Split(',').ToList();

            Console.WriteLine("Input year of publishing, please");
            book.NumOfPages = int.Parse(Console.ReadLine());

            try
            {
                shelfService.AddBook(book);
                Console.WriteLine("Thx, the book was successfully added to library!");
            }
            catch (Exception e)
            {
                Console.WriteLine("There was an error while processing the book!");
            }
        }
        private void RemoveBook(string Name)
        {
            try {
                shelfService.RemoveBook(shelfService.bookShelf.Books.Find(c => c.Name == Name));
                Console.WriteLine("The book was successfuly delited");
            }
            catch(Exception e)
            {
                Console.WriteLine("Book isn't found!" + e.Message);
            }
        }

        private void EndSession()
        {
            shelfService.SaveXMLHelp();
              
            Console.WriteLine("Thx, the progress is saved!");
        }

       
    }
}
