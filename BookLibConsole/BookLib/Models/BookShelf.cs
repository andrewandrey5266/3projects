using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace BookLib
{
    [Serializable] 
    [DataContract]
    public class BookShelf
    {
        [DataMember]
        public List<Book> Books { get; set; }

        [DataMember]
        public string Name { get; set; }

        public BookShelf() : this("default1") { }

        public BookShelf(string Name)
        {
            this.Name = Name;
            Books = new List<Book>();
        }
    }
}
