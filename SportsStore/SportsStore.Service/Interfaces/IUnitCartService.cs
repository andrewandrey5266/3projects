using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.ViewModel.Models;
using SportsStore.Domain.Entities;

namespace SportsStore.Service.Interfaces 
{
    public interface IUnitCartService
    {
       void AddItem(CartViewModel cartProductVM);    

       void RemoveItem(CartViewModel cartProductVM);   

      
    }
}
