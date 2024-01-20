using MakeUp.Extensions;
using MakeUp.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeUp.Models
{
    public class SalesReportViewModel
    {
        public string Customer { get; set; }
        public int OrderNumber { get; set; }
        public int OrdersCount { get; set; }
        public long TotalPrice { get; set; }
        public string TotalPriceStr => TotalPrice.ToCurrencyFormat();
        public DateTime SaleDateTime { get; set; }
        public string SaleDateTimeStr => DateTimeUtils.ToPersianTime(SaleDateTime) + " " + DateTimeUtils.ToPersianDate(SaleDateTime);
    }
}
