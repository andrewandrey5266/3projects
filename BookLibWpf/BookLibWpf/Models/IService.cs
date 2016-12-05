using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibWpf.Models
{
    interface IService<T>
    {
        List<T> Select();
        void Insert(T item);
        void Update(T oldItem, T newItem);
        void Delete(T item);       
    }
}
