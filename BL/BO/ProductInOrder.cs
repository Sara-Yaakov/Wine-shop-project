
namespace BO;

public class ProductInOrder
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public double BasicPrice { get; set; }
    public int Amount { get; set; }
    public List<SaleInProduct> SalesOfProduct { get; set; }
    public double FinalPrice { get; set; }

    public override string ToString() => this.ToStringProperty();


}
