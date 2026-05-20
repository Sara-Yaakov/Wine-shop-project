namespace BlApi;
using BO;

public interface ISale
{
    public int AddSale(Sale sale);
    public void UpdateSale(Sale sale);
    public void DeleteSale(int saleId);
    public List<Sale> GetAllSales();
    public Sale GetSaleById(int id);

    public Sale GetSaleByParameter(Func<Sale, bool> filter);
    public List<BO.Sale> GetAllSalesByParameter(Func<BO.Sale, bool> filter = null);

}
