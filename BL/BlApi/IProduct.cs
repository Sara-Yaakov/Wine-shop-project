namespace BlApi;
using BO;

public interface IProduct
{
    public int AddProduct(Product product);
    public void UpdateProduct(Product product);
    public void DeleteProduct(int productId);
    public List<Product> GetAllProducts();
    public Product GetProductById(int id);
    public Product GetProductByParameter(Func<Product, bool> filter);
    public List<Product> GetAllProductsByParameter(Func<BO.Product, bool> filter = null);

}