

namespace BlApi; 
using BO;

public interface IBl
{
    public ICustomer Customer { get; init;  }
    public IProduct Product { get; init; }
    public ISale Sale { get; init; }
    public ISaleInProduct SaleInProduct { get; init; }
    public IOrder Order { get; init; }
    public IProductInOrder  ProductInOrder { get; init; }

}
