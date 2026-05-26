using BlApi;
using static BO.Tools;
using System.Linq;
namespace BlImplementation;

internal class ProductImplementation : IProduct
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public int AddProduct(BO.Product product)
    {
        return _dal.Product.Create(product.ConvertBOProductToDOProduct());
    }

    public void DeleteProduct(int productId)
    {
        _dal.Product.Delete(productId);
    }

    public List<BO.Product> GetAllProducts()
    {
        return _dal.Product.ReadAll()
            .Where(p => p != null)
            .Select(p => p!.ConvertDOProductToBOProduct())
            .ToList();
    }

    public List<BO.Product> GetAllProductsByParameter(Func<BO.Product, bool> filter = null)
    {
        var list = _dal.Product.ReadAll().Where(p => p != null).Select(p => p!.ConvertDOProductToBOProduct());
        if (filter != null)
            list = list.Where(filter);
        return list.ToList();
    }

    public BO.Product GetProductById(int id)
    {
        var doProd = _dal.Product.Read(id);
        if (doProd == null)
            throw new BO.BlException.BlIdNotExistsException($"Product {id} not found");
        return doProd.ConvertDOProductToBOProduct();
    }

    public BO.Product GetProductByParameter(Func<BO.Product, bool> filter)
    {
        return _dal.Product.ReadAll()
                .Where(p => p != null)
                .Select(p => p!.ConvertDOProductToBOProduct())
                .FirstOrDefault(filter);
    }

    public void UpdateProduct(BO.Product product)
    {
        _dal.Product.Update(product.ConvertBOProductToDOProduct());
    }
}

