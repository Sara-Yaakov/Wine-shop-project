

using DO;
using DalApi;
using static Dal.DalExceptions;

namespace Dal;

    public class SaleImplementation : ISale
{
    public int Create(Sale sale)
    {
        int myId = DataSource.Config.CurrentRunningSalesId;
        Sale sale2 = sale with { Id = myId };
        DataSource.sales.Add(sale2);
        return myId;
        throw new NotImplementedException("Sale creating function failed");
    }

    public void Delete(int id)
    {
        if (DataSource.sales.Exists((s) => s.Id == id))
        {

            DataSource.sales.Remove(DataSource.sales.Find((s) => s.Id == id));
        }
        throw new DalIdAlreadyExistsException("Sale deleting ended with an error, the id is not exists");
    }

    public Sale? Read(int id)
    {
        if (DataSource.sales.Exists((s) => s.Id == id))
        {

            return DataSource.sales.Find((s) => s.Id == id);
        }
        throw new DalIdNotFaundException("Sale was not in the list");
    }

    public List<Sale?> ReadAll()
    {
        return DataSource.sales;
        throw new NotImplementedException("Read all sales function ended with an unkown error");

    }

    public void Update(Sale sale)
    {
        if (DataSource.sales.Exists((p) => p.Id == sale.Id))
        {

            Delete(sale.Id);
            DataSource.sales.Add(sale);
        }
        throw new DalIdNotFaundException("Sale was not found");
    }
}

