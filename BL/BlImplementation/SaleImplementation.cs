using BlApi;
using Dal;
using static BO.Tools;
using System.Linq;

namespace BlImplementation;

internal class SaleImplementation : ISale
{
    DalApi.IDal _dal = DalApi.Factory.Get;
    
    public int AddSale(BO.Sale sale)
    {
        try
        {
            return _dal.Sale.Create(sale.ConvertBOSaleToDOSale());
        }
        catch (Dal.DalExceptions.DalIdAlreadyExistsException ex)
        {
            throw new BO.BlException.BlIdAlreadyExistsException(ex.Message, ex);
        }
    }

    public void DeleteSale(int saleId)
    {
        try
        {
            _dal.Sale.Delete(saleId);
        }
        catch (Dal.DalExceptions.DalIdNotFoundException ex)
        {
            throw new BO.BlException.BlIdNotExistsException(ex.Message, ex);
        }
    }

    public List<BO.Sale> GetAllSales()
    {
        return _dal.Sale.ReadAll()
            .Where(s => s != null)
            .Select(s => s!.ConvertDOSaleToBOSale())
            .ToList();
    }

    public List<BO.Sale> GetAllSalesByParameter(Func<BO.Sale, bool> filter = null)
    {
        var list = _dal.Sale.ReadAll().Where(s => s != null).Select(s => s!.ConvertDOSaleToBOSale());
        if (filter != null)
            list = list.Where(filter);
        return list.ToList();
    }

    public BO.Sale GetSaleById(int id)
    {
        try
        {
            var s = _dal.Sale.Read(id);
            if (s == null) throw new Dal.DalExceptions.DalIdNotFoundException($"Sale {id} not found");
            return s.ConvertDOSaleToBOSale();
        }
        catch (Dal.DalExceptions.DalIdNotFoundException ex)
        {
            throw new BO.BlException.BlIdNotExistsException(ex.Message, ex);
        }
    }

    public BO.Sale GetSaleByParameter(Func<BO.Sale, bool> filter)
    {
        return _dal.Sale.ReadAll()
       .Where(s => s != null)
       .Select(s => s!.ConvertDOSaleToBOSale()).
       FirstOrDefault(filter);
    }

    public void UpdateSale(BO.Sale sale)
    {
        try
        {
            _dal.Sale.Update(sale.ConvertBOSaleToDOSale());
        }
        catch (Dal.DalExceptions.DalIdNotFoundException ex)
        {
            throw new BO.BlException.BlIdNotExistsException(ex.Message, ex);
        }
    }
}

