namespace BlApi;
using BO;

public interface ISale
{
    public int AddSale(Sale sale);
    public void UpdateSale(Sale sale);
    public void DeleteSale(Sale sale);
    public List<Sale> GetAllSales();
    public Sale GetSaleById(int id);

    public Sale GetSaleByParameter(Func<Sale, bool> filter);
}
