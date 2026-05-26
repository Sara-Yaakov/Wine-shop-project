using BlApi;
using static BO.Tools;
namespace BlImplementation;



internal class CustomerImplementation : ICustomer // בעיה עם הפילטרים שמחכים לקבל BO.CUSTOMER ולהעביר הלאה פילטר של DO.CUSTOMER
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public int AddCustomer(BO.Customer customer)
    {
        return _dal.Customer.Create(customer.convertBOCustomerToDOCustomer());
    }

    public void DeleteCustomer(int id)
    {
        _dal.Customer.Delete(id);
    }
    public void UpdateCustomer(BO.Customer customer)
    {
        _dal.Customer.Update(customer.convertBOCustomerToDOCustomer());
    }

    public bool IsCustomerExists(int id)
    {
        return _dal.Customer.Read(id) != null;
    }

    public BO.Customer? GetCustomerById(int id)
    {

        return _dal.Customer.Read(id).convertDOCustomerToBOCustomer();

    }

    public BO.Customer GetCustomerByParameter(Func<BO.Customer, bool> filter)
    {
        return _dal.Customer.ReadAll()
               .Select(c => c.convertDOCustomerToBOCustomer()).
               FirstOrDefault(filter);
    }
   
    public List<BO.Customer> GetAllCustomers()
    {
        var list = _dal.Customer.ReadAll();
        return list.Select(c => c.convertDOCustomerToBOCustomer()).ToList();
    }

    public List<BO.Customer> GetAllCustomersByParameter(Func<BO.Customer, bool> filter = null)
    {

        // FILTER CAST TO Func<BO.Customer, bool>
        //כרגע לא משתמש בפונקצית סינון של dal
        var list = _dal.Customer.ReadAll().Select(c => c.convertDOCustomerToBOCustomer());
        if(filter != null)
            list = list.Where(filter);
                return list.ToList();
    }

}

