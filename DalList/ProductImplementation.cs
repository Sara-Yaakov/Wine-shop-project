
using DalApi;
using DO;
using System.Linq;
using static Dal.DalExceptions;

namespace Dal;

internal class ProductImplementation : IProduct
{
    public int Create(Product product)
    {
        int curId = DataSource.Config.CurrentRunningProductsId;
        Product newProduct = product with { Id = curId };
        DataSource.products.Add(newProduct);
        return curId;
    }

    public void Delete(int id)
    {
        var productToDelete = DataSource.products.SingleOrDefault(p => p.Id == id);
        if (productToDelete==null)
            throw new DalIdNotFoundException("Product deleting/updating ended with an error, the id is not exists");
        DataSource.products.Remove(productToDelete);
        
    }

    public Product? Read(int id)
    {
        var productToRead = DataSource.products.SingleOrDefault(p => p.Id == id);
        if(productToRead==null)
            throw new DalIdNotFoundException("Product is not in the list");
        return productToRead;
    }

    public Product? Read(Func<Product, bool> filter)
    {
        var product = DataSource.products.FirstOrDefault(filter);
        if (product == null)
            throw new DalIdNotFoundException("No product found matching the filter");
        return product;
    }

    public List<Product?> ReadAll(Func<Product,bool>? filter=null)
    {
        return filter == null
             ? DataSource.products.ToList()
             : DataSource.products.Where(filter).ToList();
    }

    public void Update(Product product)
    {
        var existingProductIndex = DataSource.products.FindIndex(p => p.Id == product.Id);
        if (existingProductIndex == -1)
            throw new DalIdNotFoundException("Product is not in the list");
        DataSource.products[existingProductIndex] = product;
    }


}

