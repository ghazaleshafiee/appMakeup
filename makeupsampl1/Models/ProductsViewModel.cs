using MakeUp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUp.Models
{
    public class ProductsViewModel
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public long Price { get; set; }
        public string PriceStr => Price.ToCurrencyFormat();
        public string number { get; set; }

        public string num { get; set; }
    }
}
