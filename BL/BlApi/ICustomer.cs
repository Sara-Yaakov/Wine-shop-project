namespace BlApi;
using BO;
public interface ICustomer
{
    public int AddCustomer(Customer customer);
    public void UpdateCustomer(Customer customer);
    public void DeleteCustomer(int id);
    public Customer GetCustomerById(int id);
    public Customer GetCustomerByParameter(Func<Customer, bool> filter);
    public List<Customer> GetAllCustomersByParameter(Func<DO.Customer, bool> filter = null);
    public List<Customer> GetAllCustomers();
    public bool IsCustomerExists(int id);
}
