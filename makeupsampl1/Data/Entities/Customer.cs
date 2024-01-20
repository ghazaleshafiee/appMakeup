using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUp.Data.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Ferstname { get; set; }

        [MaxLength(500)]
        public string lastname { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        [Index]
        [Required]
        [MaxLength(100)]
        public string Tell { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
