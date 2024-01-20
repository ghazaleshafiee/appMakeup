using MakeUp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUp.Models
{
    public class OrdersViewModel
    {
        public int ProductId { get; set; }
        public string ProductCaption { get; set; }
        public int Count { get; set; }
        public long Price { get; set; }
        public string PriceStr => Price.ToCurrencyFormat();
    }
}
