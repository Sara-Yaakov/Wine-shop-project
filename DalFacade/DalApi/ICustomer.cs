

namespace DalApi;
using DO;

public interface ICustomer
{
    int Create(Customer customer);
    Customer? Read(int id);
    List<Customer> ReadAll();
    void Update(Customer customer);
    void Delete(int id);
}
