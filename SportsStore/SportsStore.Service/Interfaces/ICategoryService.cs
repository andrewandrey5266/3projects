using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Service.Interfaces
{
    public  interface ICategoryService
    {
        IEnumerable<string> GetCategories();
    }
}
