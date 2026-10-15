

using DO;
using DalApi;
using static Dal.DalExceptions;

namespace Dal;

internal class CustomerImplementation : ICustomer
{
    public int Create(Customer customer)
    {
        if (DataSource.customers.Any(c => c.Id == customer.Id))
            throw new DalIdAlreadyExistsException("Customer creating ended with an error, the id already exists");
        DataSource.customers.Add(customer);
        return customer.Id;
    }

    public void Delete(int id)
    {
        var customerToDelete = DataSource.customers.SingleOrDefault(c => c.Id == id);
        if (customerToDelete == null)
            throw new DalIdNotFoundException("Customer deleting/updating ended with an error, the id is not exists");
        DataSource.customers.Remove(customerToDelete);
    }

    public Customer? Read(int id)
    {
        var customerToRead = DataSource.customers.SingleOrDefault(c => c.Id == id);
        if (customerToRead == null)
            throw new DalIdNotFoundException("Customer is not in the list");
        return customerToRead;
    }

    public Customer? Read(Func<Customer, bool> filter)
    {
        var customer= DataSource.customers.FirstOrDefault(filter);
        if (customer == null)
            throw new DalIdNotFoundException("No customer found matching the filter");
        return customer;
    }

    public List<Customer?> ReadAll(Func<Customer, bool>? filter = null)
    {
        return filter == null
             ? DataSource.customers.ToList()
             : DataSource.customers.Where(filter).ToList();
    }

   

    public void Update(Customer customer)
    {
        var existingCustomerIndex = DataSource.customers.FindIndex(c => c.Id == customer.Id);
        if (existingCustomerIndex == -1)
            throw new DalIdNotFoundException("Customer is not in the list");
        DataSource.customers[existingCustomerIndex] = customer;
    }
}

