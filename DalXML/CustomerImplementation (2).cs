using DalApi;
using DO;
using System.Xml.Serialization;
using static Dal.DalExceptions;

namespace Dal;
internal class CustomerImplementation : ICustomer
{
    const string CUSTOMERS_FILE_PATH = "../xml/customers.xml";
    private List<Customer> LoadList()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));

        if (!File.Exists(CUSTOMERS_FILE_PATH))
            return new List<Customer>();

        using StreamReader sr = new StreamReader(CUSTOMERS_FILE_PATH);
        return serializer.Deserialize(sr) as List<Customer> ?? new List<Customer>();
    }
    private void SaveList(List<Customer> sales)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
        using StreamWriter sw = new StreamWriter(CUSTOMERS_FILE_PATH);
        serializer.Serialize(sw, sales);
    }
    public int Create(Customer customer)
    {
        List<Customer> customersList = LoadList();
        if(customersList.Any(c=> c.Id == customer.Id))
            throw new DalIdAlreadyExistsException("Customer creating ended with an error, the id already exists");
        customersList.Add(customer);
        SaveList(customersList);
        return customer.Id;
    }
    public void Delete(int id)
    {
        List<Customer> customersList= LoadList();
        var customerToDelete = customersList.SingleOrDefault(c => c.Id == id);
        if (customerToDelete == null)
            throw new DalIdNotFoundException("Customer deleting/updating ended with an error, the id is not exists");
        customersList.Remove(customerToDelete);
        SaveList(customersList);
    }
    public Customer? Read(int id)
    {
        List<Customer> customersList= LoadList();
        var customerToRead = customersList.SingleOrDefault(c => c.Id == id);
        if (customerToRead == null)
             throw new DalIdNotFoundException("Customer is not in the list");
        return customerToRead;
    }

    public Customer? Read(Func<Customer, bool> filter)
    {
        List<Customer> customersList= LoadList();
        var customer = customersList.FirstOrDefault(filter);
        if (customer == null)
            throw new DalIdNotFoundException("No customer found matching the filter");
        return customer;
    }

    public List<Customer?> ReadAll(Func<Customer, bool>? filter = null)
    {
        List<Customer> customersList= LoadList();
        return filter == null
                 ?customersList.ToList()
                 : customersList.Where(filter).ToList();
    }

    public void Update(Customer customer)
    {
        List<Customer> customersList = LoadList();
        var existingCustomerIndex = customersList.FindIndex(c => c.Id == customer.Id);
        if (existingCustomerIndex == -1)
            throw new DalIdNotFoundException("Customer is not in the list");
        customersList[existingCustomerIndex] = customer;
        SaveList(customersList);
    }
}
