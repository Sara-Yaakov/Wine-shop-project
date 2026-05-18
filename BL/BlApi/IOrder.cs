using BO;
namespace BlApi;

public interface IOrder
{
    public void SearchSaleForProduct(ProductInOrder productInOrder, bool isCustomerExists);
    public void CalcTotalPriceForProduct(ProductInOrder productInOrder);
    public void CalcTotalPrice(Order order);
    public void AddProductToOrder(Order order, int productId, int amount);
    public void DoOrder(Order order);

}
