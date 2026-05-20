namespace BlImplementation;

public class Bl : BlApi.IBl
{
    public BlApi.ISale Sale => new SaleImplementation();
    public BlApi.ICustomer Customer => new CustomerImplementation();
    public BlApi.IProduct Product => new ProductImplementation();
    public BlApi.IOrder Order => new OrderImplementation();
}