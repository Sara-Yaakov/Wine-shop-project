namespace BlApi;
public interface ICustomer
{
    public int AddCustomer(BO.Customer customer);
    public void UpdateCustomer(BO.Customer customer);
    public void DeleteCustomer(int id);
    public BO.Customer GetCustomerById(int id);
    public BO.Customer GetCustomerByParameter(Func<BO.Customer, bool> filter);
    public List<BO.Customer> GetAllCustomersByParameter(Func<BO.Customer, bool> filter = null);
    public List<BO.Customer> GetAllCustomers();
    public bool IsCustomerExists(int id);
}
