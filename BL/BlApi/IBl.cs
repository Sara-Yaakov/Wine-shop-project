

namespace BlApi; 
using BO;

public interface IBl
{
    public ISale Sale { get;  }
    public ICustomer Customer { get;}
    public IProduct Product { get;  }
    public IOrder Order { get; }

}
