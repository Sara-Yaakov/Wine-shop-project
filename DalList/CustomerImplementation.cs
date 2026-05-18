

using DO;
using DalApi;
using static Dal.DalExceptions;

namespace Dal;

public class CustomerImplementation : ICustomer
{
    public int Create(Customer customer)//TODO
    {

        DataSource.customers.Add(customer);
        return customer.Id;
        throw new NotImplementedException("Customer creating function failed");
       
    }

    public void Delete(int id)
    {

        if (DataSource.customers.Exists((c) => c.Id == id))
        {

            DataSource.customers.Remove(DataSource.customers.Find((c) => c.Id == id));
        }//TODO
        throw new DalIdAlreadyExistsException("Customer deleting ended with an error, the id is not exists");
    }

    public Customer? Read(int id)
    {
        if (DataSource.customers.Exists((c) => c.Id == id))
        {

            return DataSource.customers.Find((c) => c.Id == id);
        }
        throw new DalIdNotFaundException("Customer is not in the list");
    }

    public List<Customer?> ReadAll()
    {
        return DataSource.customers;//TODO
        throw new NotImplementedException("Read all customers function ended with an unkown error");
    }

    public void Update(Customer customer)
    {
        if (DataSource.customers.Exists((c) => c.Id == customer.Id))//TODO
        {

            Delete(customer.Id);
            DataSource.customers.Add(customer);
        }
        throw new DalIdNotFaundException("Customer was not found");
    }
}

