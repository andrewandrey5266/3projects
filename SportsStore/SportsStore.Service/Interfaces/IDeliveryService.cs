using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.ViewModel.Models;
namespace SportsStore.Service.Interfaces
{
    public interface IDeliveryService
    {
        void SaveDelivery(DeliveryViewModel delivery);
    }
}
