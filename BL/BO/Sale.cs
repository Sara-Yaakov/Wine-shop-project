

namespace BO;

//sale class: each sale has unique id,product id,required amount,price after discount,
//flag that used to know if the sale is for club members only,
//the start date and end the date of the sale
public class Sale()
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int RequiredAmount { get; set; }
    public int PriceAfterDiscount { get; set; }
    public bool IsForClubMembersOnly { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public override string ToString() => this.ToStringProperty();
}
