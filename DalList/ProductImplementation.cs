
using DO;
using DalApi;
using static Dal.DalExceptions;

namespace Dal;

    public class ProductImplementation : IProduct
{
    public int Create(Product product)
    {
        int myId = DataSource.Config.CurrentRunningProductsId;
        Product product2 = product with { Id = myId };
        DataSource.products.Add(product2);
        return myId;
        throw new NotImplementedException("Product creating function failed");
    }

    public void Delete(int id)
    {
        if (DataSource.products.Exists((p) => p.Id == id))
        {

            DataSource.products.Remove(DataSource.products.Find((p) => p.Id == id));
        }
        throw new DalIdAlreadyExistsException("Product deleting ended with an error, the id is not exists");
    }

    public Product? Read(int id)
    {
        if (DataSource.products.Exists((p) => p.Id == id))
        {

            return DataSource.products.Find((p) => p.Id == id);
        }
        throw new DalIdNotFaundException("Product was not in the list");
    }

    public List<Product?> ReadAll()
    {
        return DataSource.products;
        throw new NotImplementedException("Read all products function ended with an unkown error");
    }

    public void Update(Product product)
    {
        if (DataSource.products.Exists((p) => p.Id == product.Id))
        {

            Delete(product.Id);
            DataSource.products.Add(product);
        }
        throw new DalIdNotFaundException("Product was not found");
    }

    ///

}

