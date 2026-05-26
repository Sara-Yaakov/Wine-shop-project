
using BlApi;
using static BO.Tools;
using System.Linq;
namespace BlImplementation;

internal class ProductImplementation : IProduct
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public int AddProduct(BO.Product product)
    {
        return _dal.Product.Create(product.convertBOProductToDOProduct());
    }

    public void DeleteProduct(int productId)
    {
        _dal.Product.Delete(productId);
    }

    public List<BO.Product> GetAllProducts()
    {
        return _dal.Product.ReadAll()
            .Select(p => p.convertDOProductToBOProduct())
            .ToList();
    }

    public List<BO.Product> GetAllProductsByParameter(Func<BO.Product, bool> filter = null)
    {

        // FILTER CAST TO Func<BO.Customer, bool>
        //כרגע לא משתמש בפונקצית סינון של dal
        var list = _dal.Product.ReadAll().Select(p => p.convertDOProductToBOProduct());
        if (filter != null)
            list = list.Where(filter);
        return list.ToList();
    }

    public BO.Product GetProductById(int id)
    {
        return _dal.Product.Read(id).convertDOProductToBOProduct();
    }

    public BO.Product GetProductByParameter(Func<BO.Product, bool> filter)
    {

        // FILTER CAST TO Func<BO.PRODUCT, bool>
        //כרגע לא משתמש בפונקצית סינון של dal
        return _dal.Product.ReadAll()
                .Select(p => p.convertDOProductToBOProduct()).
                FirstOrDefault(filter);
    }

    public void UpdateProduct(BO.Product product)
    {
        _dal.Product.Update(product.convertBOProductToDOProduct());
    }
}

