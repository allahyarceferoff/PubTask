using OnlinePub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinePub.Repositories
{
    public class FakeRepo
    {
        public List<Beer> GetAll()
        {
            return new List<Beer>
            {
                new Beer{Id=1, BeerName="Efes", Volume=4.0m, BeerCost=5.6m, ImagePath="/Images/Efes.png"},
                new Beer{Id=1, BeerName="Jack Daniels", Volume=6.0m, BeerCost=24.5m, ImagePath="/Images/Jack.png"},
                new Beer{Id=2, BeerName="Miles Rose Zinfandel", Volume=80.0m, BeerCost=34.9m, ImagePath="/Images/Zinfandel.png"},
                new Beer{Id=3, BeerName="Kuller9", Volume=4.5m, BeerCost=4.3m, ImagePath="/Images/Kuler.png"},
                new Beer{Id=3, BeerName="Anthem", Volume=3.5m, BeerCost=119.9m, ImagePath="/Images/Anthem.png"},
                new Beer{Id=3, BeerName="Nemiroff", Volume=40.0m, BeerCost=90.2m, ImagePath="/Nemiroff/skol.png"}
            };
        }
    }
}
