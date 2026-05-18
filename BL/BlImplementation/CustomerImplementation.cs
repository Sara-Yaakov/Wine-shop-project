//using static Dal.DalExceptions;
using BlApi;
namespace BlImplementation;



internal class CustomerImplementation : ICustomer // בעיה עם הפילטרים שמחכים לקבל BO.CUSTOMER ולהעביר הלאה פילטר של DO.CUSTOMER
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public int AddCustomer(BO.Customer customer)
    {
        DO.Customer customerToAdd = new DO.Customer
        {
            Address = customer.Address,
            IsClubMember = customer.IsClubMember,
            Name = customer.Name,
            PhoneNumber = customer.PhoneNumber
        };
        return _dal.Customer.Create(customerToAdd);
    }

    public void DeleteCustomer(int id)
    {
        _dal.Customer.Delete(id);
    }

    public bool IsCustomerExists(int id)
    {
        return _dal.Customer.Read(id) != null;
    }

    public BO.Customer? GetCustomerById(int id)
    {
        DO.Customer customerToRead = _dal.Customer.Read(id);
        return new BO.Customer
        {
            Address = customerToRead.Address,
            IsClubMember = customerToRead.IsClubMember,
            Name = customerToRead.Name,
            PhoneNumber = customerToRead.PhoneNumber,
            Id = id
        };

    }

    public BO.Customer GetCustomerByParameter(Func<BO.Customer, bool> filter)
    {
        DO.Customer customerToRead = _dal.Customer.Read(filter);
        return new BO.Customer
        {
            Address = customerToRead.Address,
            IsClubMember = customerToRead.IsClubMember,
            Name = customerToRead.Name,
            PhoneNumber = customerToRead.PhoneNumber,
            Id = customerToRead.Id
        };
    }
    public List<BO.Customer?> ReadAll(Func<BO.Customer, bool>? filter = null)
    {
        List<DO.Customer> dalCustomers = (List<DO.Customer>)_dal.Customer.ReadAll(filter);
        return dalCustomers.Select(c => new     BO.Customer
        {
            Address = c.Address,
            IsClubMember = c.IsClubMember,
            Name = c.Name,
            PhoneNumber = c.PhoneNumber,
            Id = c.Id
        }).ToList();
    }

    //public List<Customer> ReadAll(bool v, Func<Customer, bool>? filter = null)
    //{
    //    List<DO.Customer> dalCustomers = DalApi.Factory.Get.Customer.ReadAll(v, filter);
    //    return dalCustomers.Select(c => new Customer
    //    {
    //        Address = c.Address,
    //        IsClubMember = c.IsClubMember,
    //        Name = c.Name,
    //        PhoneNumber = c.PhoneNumber,
    //        Id = c.Id
    //    }).ToList();
    //}

   

    public void UpdateCustomer(BO.Customer customer)
    {
        DO.Customer customerToUpdate = new DO.Customer
        {
            Id = customer.Id,
            Address = customer.Address,
            IsClubMember = customer.IsClubMember,
            Name = customer.Name,
            PhoneNumber = customer.PhoneNumber
        };
        _dal.Customer.Update(customerToUpdate);
    }


    public List<BO.Customer> GetAllCustomers()
    {
        List<BO.Customer> blCustomers= new List<BO.Customer>();
        List<DO.Customer?> dalCustomers = _dal.Customer.ReadAll();
        foreach(DO.Customer customer in dalCustomers)
        {
            blCustomers.Add(new BO.Customer
            {
                Id = customer.Id,
                Address = customer.Address,
                IsClubMember = customer.IsClubMember,
                Name = customer.Name,
                PhoneNumber = customer.PhoneNumber
            });
        }
        return blCustomers;
    }

}

