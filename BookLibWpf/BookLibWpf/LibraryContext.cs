﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BookLibWpf.Models;
namespace BookLibWpf
{
    public class LibraryContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}
