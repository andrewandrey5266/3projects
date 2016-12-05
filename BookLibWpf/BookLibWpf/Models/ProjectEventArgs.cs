using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibWpf.Models
{
    public class ProjectEventArgs : EventArgs
    {
        public Book Book { get; set; }
        public ProjectEventArgs(Book book)
        {
            this.Book = book;
        }
    }
}
