namespace BlApi;
using BO;

public interface IProduct
{
    public int AddProduct(Product product);
    public void UpdateProduct(Product product);
    public void DeleteProduct(Product product);
    public List<Product> GetAllProducts();
    public Product GetProductById(int id);
    public Product GetProductByParameter(Func<Product, bool> filter);
}