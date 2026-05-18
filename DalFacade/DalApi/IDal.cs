

namespace DalApi;

public interface IDal
{
    public ICustomer Customer { get;  }
    public IProduct Product { get; }
    public ISale Sale { get; }

}
