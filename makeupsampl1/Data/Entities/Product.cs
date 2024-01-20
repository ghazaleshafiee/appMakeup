using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUp.Data.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Caption { get; set; }
        public long Price { get; set; }
        [MaxLength(200)]
        public string numder { get;  set; }

        public string num { get; set; }


        public ICollection<Order> Orders { get; set; }



    }
}
