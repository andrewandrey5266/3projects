using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace BookLib
{
    [Serializable]
    [DataContract]
    public class Book
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int NumOfPages { get; set; }

        [DataMember]
        public List<string> Authors { get; set; }

        [DataMember]
        public int Year { get; set; }

        public Book() : this("default1", 0, new List<string>(), 2000) { }

        public Book(string name, int numOfPages, List<string> authors, int year)
        {
            this.Name = name;
            this.NumOfPages = numOfPages;
            this.Authors = authors;
            this.Year = year;
        }       
    }
}
