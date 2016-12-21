using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;
namespace SportsStore.ViewModel.Models
{
    public  class DetailedProductViewModel
    {
        public Product Product { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
