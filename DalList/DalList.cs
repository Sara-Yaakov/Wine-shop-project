
using DalApi;
namespace Dal;

internal sealed class DalList : IDal
{
    private static DalList _instance;
    public ICustomer Customer => new CustomerImplementation();

    public IProduct Product => new ProductImplementation();

    public ISale Sale => new SaleImplementation();

    private DalList()
    {
    }

    public static DalList Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DalList();
            }
            return _instance;
        }
    }

}
