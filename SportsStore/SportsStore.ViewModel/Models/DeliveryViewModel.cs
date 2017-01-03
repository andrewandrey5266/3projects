using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SportsStore.Domain.Entities;
namespace SportsStore.ViewModel.Models
{
    public class DeliveryViewModel
    {
        public decimal DeliveryPrice;

        public string City { get; set; }
        public string Street { get; set; }
        public string HomeNumber { get; set; }
        public string Appartment { get; set; }
        public string PostIndex { get; set; }      
    }
}
