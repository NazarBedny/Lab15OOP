using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Stationery
    {
        public string StationeryName { get; set; }
        public string TypeStationery { get; set; }
        public int CountStationeryEveryType { get; set; }
        public string Menegers { get; set; }
        public int Cost { get; set; }
        public string NameCompanyBuyer { get; set; }
        public string ManagerWhoSell { get; set; }
        public int CountOfSellsStationery { get; set; }
        public int CostOfOneStationery { get; set; }
        public DateTime Date { get; set; }
    }
}
