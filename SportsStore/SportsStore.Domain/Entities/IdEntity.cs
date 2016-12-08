using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SportsStore.Domain.Entities
{
    public abstract class IdEntity
    {
        private String id;
        [Key]
        [Required]
        public string Id
        {
            get
            {
                return String.IsNullOrEmpty(id) == true ? (id = Guid.NewGuid().ToString()) : id;
            }
            set
            {
                id = value;
            }
        }
    }
}
