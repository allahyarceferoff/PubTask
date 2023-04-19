using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Converters;

namespace OnlinePub.Models
{
    public class Beer : Entity
    {
        public string BeerName { get; set; }
        public decimal BeerCost { get; set; }
        public decimal Volume { get; set; }
        public decimal BeerCount { get; set; }
        public decimal TotalPrice { get; set; }
        public string ImagePath { get; set; }
    }
}
