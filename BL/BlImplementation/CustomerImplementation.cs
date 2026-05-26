using BlApi;
using static BO.Tools;
using Dal;

namespace BlImplementation;



internal class CustomerImplementation : ICustomer // בעיה עם הפילטרים שמחכים לקבל BO.CUSTOMER ולהעביר הלאה פילטר של DO.CUSTOMER
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public int AddCustomer(BO.Customer customer)
    {
        try
        {
            return _dal.Customer.Create(customer.ConvertBOCustomerToDOCustomer());
        }
        catch (Dal.DalExceptions.DalIdAlreadyExistsException ex)
        {
            throw new BO.BlException.BlIdAlreadyExistsException(ex.Message, ex);
        }
    }

    public void DeleteCustomer(int id)
    {
        try
        {
            _dal.Customer.Delete(id);
        }
        catch (Dal.DalExceptions.DalIdNotFoundException ex)
        {
            throw new BO.BlException.BlIdNotExistsException(ex.Message, ex);
        }
    }
    public void UpdateCustomer(BO.Customer customer)
    {
        try
        {
            _dal.Customer.Update(customer.ConvertBOCustomerToDOCustomer());
        }
        catch (Dal.DalExceptions.DalIdNotFoundException ex)
        {
            throw new BO.BlException.BlIdNotExistsException(ex.Message, ex);
        }
    }

    public bool IsCustomerExists(int id)
    {
        try
        {
            _dal.Customer.Read(id);
            return true;
        }
        catch (Dal.DalExceptions.DalIdNotFoundException)
        {
            return false;
        }
    }

    public BO.Customer? GetCustomerById(int id)
    {
        try
        {
            var doc = _dal.Customer.Read(id);
            return doc.ConvertDOCustomerToBOCustomer();
        }
        catch (Dal.DalExceptions.DalIdNotFoundException ex)
        {
            throw new BO.BlException.BlIdNotExistsException(ex.Message, ex);
        }

    }

    public BO.Customer GetCustomerByParameter(Func<BO.Customer, bool> filter)
    {
        var list = _dal.Customer.ReadAll()
               .Select(c => c.ConvertDOCustomerToBOCustomer());

        return list.FirstOrDefault(filter);
    }
   
    public List<BO.Customer> GetAllCustomers()
    {
        var list = _dal.Customer.ReadAll();
        return list.Select(c => c.ConvertDOCustomerToBOCustomer()).ToList();
    }

    public List<BO.Customer> GetAllCustomersByParameter(Func<BO.Customer, bool> filter = null)
    {

        // FILTER CAST TO Func<BO.Customer, bool>
        //כרגע לא משתמש בפונקצית סינון של dal
        var list = _dal.Customer.ReadAll().Select(c => c.ConvertDOCustomerToBOCustomer());
        if(filter != null)
            list = list.Where(filter);
                return list.ToList();
    }

}

