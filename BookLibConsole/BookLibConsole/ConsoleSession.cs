using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
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
            if (int.Parse(Console.ReadLine()) == 1)
                shelfService.ReadWindow();

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
                DoIteration();
            }
            if (response == 2)
            {
                AddBook();
                DoIteration();
            }
            if (response == 3)
            {
                Console.WriteLine("Input book name please");
                string bookName = Console.ReadLine();
                RemoveBook(bookName);
                DoIteration();
            }
            if (response == 4)
            {
                EndSession();
            }


        }
        private void EndSession()
        {
            Console.WriteLine("Would you like to save book?\n1 - Yes\n2 - No");
            if (int.Parse(Console.ReadLine()) == 1)
                shelfService.SaveWindow();

            Console.WriteLine("Thx, the progress is saved!");
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
                Console.WriteLine("There was an error while processing the book!" + e.Message);
            }
        }
        private void RemoveBook(string Name)
        {
            try
            {
                shelfService.RemoveBook(shelfService.bookShelf.Books.Find(c => c.Name == Name));
                Console.WriteLine("The book was successfuly delited");
            }
            catch (Exception e)
            {
                Console.WriteLine("Book isn't found!" + e.Message);
            }
        }

    }
}
