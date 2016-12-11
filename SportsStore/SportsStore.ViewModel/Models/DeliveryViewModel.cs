using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.ViewModel.Models
{
    public class DeliveryViewModel
    {
        [Required(ErrorMessage = "Please enter a name")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please enter a city")]
        public string City { get; set; }

        // Post office or local store
        [Required(ErrorMessage = "Please enter a city")]
        public string LocalDepartment { get; set; }

        public string User;
        public decimal TotalPrice;

    }
}
