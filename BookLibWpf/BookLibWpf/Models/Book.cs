using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookLibWpf.Models
{
  
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int NumOfPages { get; set; }
        public int Year { get; set; }
    }
}
