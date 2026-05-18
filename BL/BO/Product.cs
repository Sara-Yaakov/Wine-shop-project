

namespace BO;

// product class: each product has an id,name,category,color,production date,
// aging period,winery,description,drinking season,quantity in stock and price.
public record Product()
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Enums.Category Category { get; set; }
    public string? Color { get; set; }
    public DateTime ProductionDate { get; set; }
    public int AgingPeriod { get; set; }
    public string Winery { get; set; }
    public string? Description { get; set; }
    public Enums.Season Season { get; set; }
    public int Amount { get; set; }
    public double Price { get; set; }

    public override string ToString() => this.ToStringProperty();


}
