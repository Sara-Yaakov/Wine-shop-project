using BlApi;
using Dal;
using static BO.Tools;
using System.Linq;
using static Dal.DalExceptions;

namespace BlImplementation;

internal class SaleImplementation : ISale
{
    DalApi.IDal _dal = DalApi.Factory.Get;
    
    public int AddSale(BO.Sale sale)
    {
       return  _dal.Sale.Create(sale.convertBOSaleToDOSale());
    }

    public void DeleteSale(int saleId)
    {
        _dal.Sale.Delete(saleId);
    }

    public List<BO.Sale> GetAllSales()
    {
        return _dal.Sale.ReadAll()
            .Select(s => s.convertDOSaleToBOSale())
            .ToList();
    }

    public List<BO.Sale> GetAllSalesByParameter(Func<BO.Sale, bool> filter = null)
    {
        // FILTER CAST TO Func<BO.sale, bool>
        //כרגע לא משתמש בפונקצית סינון של dal
        var list = _dal.Sale.ReadAll().Select(s => s.convertDOSaleToBOSale());
        if (filter != null)
            list = list.Where(filter);
        return list.ToList();
    }

    public BO.Sale GetSaleById(int id)
    {
        return _dal.Sale.Read(id).convertDOSaleToBOSale();  
    }

    public BO.Sale GetSaleByParameter(Func<BO.Sale, bool> filter)
    {
        return _dal.Sale.ReadAll()
       .Select(s => s.convertDOSaleToBOSale()).
       FirstOrDefault(filter);
    }

    public void UpdateSale(BO.Sale sale)
    {
        _dal.Sale.Update(sale.convertBOSaleToDOSale());
    }
}

