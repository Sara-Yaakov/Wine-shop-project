

using DalApi;
using DO;
using System.Linq;
using static Dal.DalExceptions;

namespace Dal;

internal class SaleImplementation : ISale
{
    public int Create(Sale sale)
    {
        int curId = DataSource.Config.CurrentRunningSalesId;
        Sale newSale = sale with { Id = curId };
        DataSource.sales.Add(newSale);
        return curId;
    }
    public void Delete(int id)
    {
        var saleToDelete = DataSource.sales.SingleOrDefault(s => s.Id == id);
        if (saleToDelete == null)
            throw new DalIdNotFoundException("Sale deleting/updating ended with an error, the id is not exists");
        DataSource.sales.Remove(saleToDelete);
    }
    public Sale? Read(int id)
    {
        var saleToRead = DataSource.sales.SingleOrDefault(s => s.Id == id);
        if (saleToRead == null)
            throw new DalIdNotFoundException("Sale was not in the list");
        return saleToRead;
    }
    public Sale? Read(Func<Sale, bool> filter)
    {
        var saleToRead = DataSource.sales.FirstOrDefault(filter);
        if (saleToRead == null)
            throw new DalIdNotFoundException("No sale found matching the filter");
        return saleToRead;
    }

    public List<Sale?> ReadAll(Func<Sale,bool>? filter=null)
    {
        return filter == null
             ? DataSource.sales.ToList()
             : DataSource.sales.Where(filter).ToList();
    }
    public void Update(Sale sale)
    {
        var existingSaleIndex = DataSource.sales.FindIndex(s => s.Id == sale.Id);
        if (existingSaleIndex == -1)
            throw new DalIdNotFoundException("Sale is not in the list");
        DataSource.sales[existingSaleIndex] = sale;
    }
}

