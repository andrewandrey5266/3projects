using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace BookLib
{
    public class BookShelfService
    {
        public BookShelf bookShelf { get; set; }
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
               
        public void SaveWindow()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "XML|*.xml|JSON|*.json";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string str = saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.LastIndexOf('.') + 1);

                if (str == "json")
                    this.SaveJSON(saveFileDialog1.FileName);
                if (str == "xml")
                    this.SaveXML(saveFileDialog1.FileName);
            }
        }
        public void ReadWindow()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";

            openFileDialog1.Filter = "XML|*.xml|JSON|*.json";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string str = openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf('.') + 1);

                    if (str == "json")
                        this.SaveJSON(openFileDialog1.FileName);
                    if (str == "xml")
                        this.SaveXML(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        
        //--privates
        private void SaveXML(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BookShelf));

            using (var sw = new StreamWriter(path))
            {
                xmlSerializer.Serialize(sw, bookShelf);
            }

        }
        private void ReadXML(string path)
        {   
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BookShelf));

            using (StreamReader sr = new StreamReader(path))
            {
                bookShelf = (BookShelf)xmlSerializer.Deserialize(sr);
            }

        }

        private void SaveJSON(string path)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (JsonWriter writer = new JsonTextWriter(new StreamWriter(path)))
            {
                serializer.Serialize(writer, bookShelf);
            }
        }                    
        private void ReadJSON(string path)
        {
            JsonSerializer serializer = new JsonSerializer();
                    
            using (JsonReader reader = new JsonTextReader(new StreamReader(path)))
            {
                bookShelf = (BookShelf)serializer.Deserialize(reader);
            }
            
        }       
    }
}
