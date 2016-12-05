using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibWpf.Models;
using BookLibWpf.Presenters;

namespace BookLibWpf.Views
{
    public interface IView<T>
    {
         event EventHandler<T> ProcessInput;
    }
}
