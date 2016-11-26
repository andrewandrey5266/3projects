using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace BookLib
{
    public class BookShelfService
    {
        public BookShelf bookShelf { get; private set; }
        public BookShelfService(BookShelf bookShelf)
        {
            this.bookShelf = bookShelf;
        }

        public void AddBook(Book book)
        {
            bookShelf.Books.Add(book);
        }
        public bool RemoveBook(Book book)
        {
            return bookShelf.Books.Remove(book);
        }
        public List<Book> GetBooks()
        {
            return bookShelf.Books;
        }

        [Obsolete("Please, use SaveXMLHelp with gui instead!")]
        public void SaveXML(string path = "BookShelf\\bookShelf1.xml")
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BookShelf));
            using (var sw = new StreamWriter(path))
            {
                xmlSerializer.Serialize(sw, bookShelf);
            }

        }
        [Obsolete("Please, use SaveXMLHelp with gui instead!")]
        public void ReadXML(string path = "BookShelf\\bookShelf1.xml")
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BookShelf));
            using (StreamReader sr = new StreamReader(path))
            {
                bookShelf = (BookShelf)xmlSerializer.Deserialize(sr);
            }

        }

        public void SaveXMLHelp()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "xml files (*.xml)|*.xml";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.SaveXML(saveFileDialog1.FileName);    
            }
        }
        public void ReadXMLHelp()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            
            openFileDialog1.InitialDirectory = "c:\\";
            
            openFileDialog1.Filter = "xml files (*.xml)|*.xml";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {               
                try
                {
                    this.ReadXML(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
