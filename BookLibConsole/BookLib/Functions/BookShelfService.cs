using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.IO;
namespace BookLib
{
    public class BookShelfService
    {
        private BookShelf bookShelf;
        public BookShelfService() { }
        public BookShelfService(BookShelf bookShelf)
        {
            this.bookShelf = bookShelf;
        }

        public void AddBook(Book book)
        {

            bookShelf.books.Add(book);
        }
        public bool Remove(Book book)
        {
            return bookShelf.books.Remove(book);
        }
        public List<Book> GetBooks()
        {
            return bookShelf.books;
        }

        public void SaveXML(string path = "BookShelf", string fileName = "bookShelf1.xml")
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BookShelf));
            using (var sw = new StreamWriter
                (Path.Combine(Environment.CurrentDirectory, string.Format(@"{1}\{2}", path, fileName)))
            {
                xmlSerializer.Serialize(sw, bookShelf);
            }

        }

        public void ReadXML(string path = "BookShelf", string fileName = "bookShelf1.xml")
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BookShelf));
            using (StreamReader sr = new StreamReader
                (string.Format(@"{0}{1}\{2}", Environment.CurrentDirectory, path, fileName)))
            {
                bookShelf = (BookShelf) xmlSerializer.Deserialize(sr);
            }          
            
        }
    }
}
