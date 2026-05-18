
namespace BO;

public class Order
{
    public bool IsClubMember { get; set; }
    public List<ProductInOrder> Products { get; set; }
    public double TotalPrice{ get; set; }

    public override string ToString() => Tools.ToStringProperty(this);
}
  


