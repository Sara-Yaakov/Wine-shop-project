namespace BO;

public class SaleInProduct
{
    public int SaleId { get; set; }
    public int ProductId { get; set; }
    public int ProductAmount { get; set; }
    public double Price { get; set; }
    public bool IsForClubMembersOnly { get; set; }

    public override string ToString() => this.ToStringProperty();


}
