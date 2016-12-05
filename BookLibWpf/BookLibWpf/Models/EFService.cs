using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BookLibWpf.Models
{
    public class EFService : IService<Book>
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
        public void Update(Book oldItem, Book newItem)
        {
            var temp = from c in context.Books
                       where
                           c.Name == oldItem.Name &&
                           c.Author == oldItem.Author
                       select c;

            foreach (var c in temp)
            {
                c.Name = newItem.Name;
                c.Author = newItem.Author;
            }
            context.SaveChanges();
                          
        }
        public void Delete(Book item)
        {
            var temp = from c in context.Books
                       where c.Author == item.Author &&
                       c.Name == item.Name
                       select c;

            context.Books.RemoveRange(temp);
            context.SaveChanges();
        }
    }
}
