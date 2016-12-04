using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace BookLibWpf
{
    public class EFService
    {
        private LibraryContext context;
        public EFService(LibraryContext context) { this.context = context; }

        public List<Book> Select()
        {
            return context.Books.ToList();
        }
        public void Insert(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }
        public void Delete(string name, string author)
        {
            var temp = from c in context.Books.ToList()
                       where c.Author == author &&
                       c.Name == name
                       select c;

            context.Books.RemoveRange(temp);
            context.SaveChanges();

        }
        public void Update(string name, string author, Book book)
        {
            var temp = from c in context.Books
                       where
                           c.Name == name &&
                           c.Author == author
                       select c;

            foreach (var c in temp)
            {
                c.Name = book.Name;
                c.Author= book.Author;
            }
            context.SaveChanges();
        }

    }
}
