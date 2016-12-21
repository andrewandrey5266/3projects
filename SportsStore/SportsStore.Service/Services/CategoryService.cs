using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Service.Interfaces;
using SportsStore.Context;
namespace SportsStore.Service.Services
{
    public  class CategoryService: ICategoryService
    {
        EFDbContext context = new EFDbContext();


        public IEnumerable<string> GetCategories()
        {
            return context.Categories.Select(i => i.Name);
        }
    }
}
