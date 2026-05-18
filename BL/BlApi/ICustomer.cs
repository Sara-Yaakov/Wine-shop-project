namespace BlApi;
using BO;
public interface ICustomer
{
    public int AddCustomer(Customer customer);
    public void UpdateCustomer(Customer customer);
    public void DeleteCustomer(int id);
    public List<Customer> GetAllCustomers();
    public Customer GetCustomerById(int id);
    public Product GetCustomerByParameter(Func<Customer, bool> filter);
    public bool IsCustomerExists(int id);
}
