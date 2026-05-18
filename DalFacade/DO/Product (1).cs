using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    // product class: each product has an id,name,category,color,production date,
    // aging period,winery,description,drinking season,quantity in stock and price.
    public record Product(
        int Id, 
        string Name,
        Category Category, 
        string Color,
        DateTime ProductionDate,
        int AgingPeriod,
        string Winery, 
        string Description, 
        Season Season,
        int Amount, 
        double Price) 
    {
        public Product(int V) : this(0, "", Category.wine, "", DateTime.Now,0, "", "", Season.summer, 0, 0)
        {
        }
        
        
    }
}
