using DalApi;
using DalXml;
using DO;
using System.Xml.Linq;
using static Dal.DalExceptions;

namespace Dal;

internal class ProductImplementation : IProduct
{
    private const string PRODUCTS_FILE_PATH = "../xml/products.xml";

    private const string ELEMENT_PRODUCT = "Product";
    private const string ID = "Id";
    private const string NAME = "Name";
    private const string CATEGORY = "Category";
    private const string COLOR = "Color";
    private const string PRODUCTION_DATE = "ProductionDate";
    private const string AGING_PERIOD = "AgingPeriod";
    private const string WINERY = "Winery";
    private const string DESCRIPTION = "Description";
    private const string SEASON = "Season";
    private const string AMOUNT = "Amount";
    private const string PRICE = "Price";

    private static XElement LoadXml()
    {
        if (!File.Exists(PRODUCTS_FILE_PATH))
            new XElement("ArrayOfProduct").Save(PRODUCTS_FILE_PATH);

        return XElement.Load(PRODUCTS_FILE_PATH);
    }

    private static void SaveXml(XElement xml)
    {
        xml.Save(PRODUCTS_FILE_PATH);
    }

    public int Create(Product product)
    {
        XElement productsList = LoadXml();
        int curId = Config.ProductNum;
        XElement newProduct = new XElement(ELEMENT_PRODUCT,
            new XElement(ID, curId),
            new XElement(NAME, product.Name),
            new XElement(CATEGORY, product.Category),
            new XElement(COLOR, product.Color),
            new XElement(PRODUCTION_DATE, product.ProductionDate),
            new XElement(AGING_PERIOD, product.AgingPeriod),
            new XElement(WINERY, product.Winery),
            new XElement(DESCRIPTION, product.Description),
            new XElement(SEASON, product.Season),
            new XElement(AMOUNT, product.Amount),
            new XElement(PRICE, product.Price)
        );
        productsList.Add(newProduct);
        SaveXml(productsList);

        return curId;
    }

    public void Delete(int id)
    {
        XElement productsList = LoadXml();
        XElement productToDelete = productsList.Descendants(ELEMENT_PRODUCT)
            .FirstOrDefault(p => int.Parse(p.Element(ID).Value) == id);
        if (productToDelete == null)
            throw new DalIdNotFoundException("Product id not found");
        productToDelete.Remove();
        SaveXml(productsList);
    }

    public Product Read(int id)
    {
        XElement productsList = LoadXml();
        XElement productElement = productsList.Descendants(ELEMENT_PRODUCT)
            .FirstOrDefault(p => int.Parse(p.Element(ID).Value) == id);
        if (productElement == null)
            throw new DalIdNotFoundException("Product id not found");
        return XElementToProduct(productElement);
    }

    public Product Read(Func<Product, bool> filter)
    {
        var products = ReadAll();
        Product product = products.FirstOrDefault(filter);
        if (product == null)
            throw new DalIdNotFoundException("No product matches the filter");
        return product;
    }

    public List<Product> ReadAll(Func<Product, bool>? filter = null)
    {
        XElement productsList = LoadXml();
        var products = (from p in productsList.Elements(ELEMENT_PRODUCT)
                        select XElementToProduct(p)).ToList();
        return filter == null ? products : products.Where(filter).ToList();
    }

    public void Update(Product product)
    {
        XElement productsList = LoadXml();
        XElement productElement = productsList.Elements(ELEMENT_PRODUCT)
            .FirstOrDefault(p => int.Parse(p.Element(ID).Value) == product.Id);
        if (productElement == null)
            throw new DalIdNotFoundException("Product id not found");
        productElement.Element(NAME).SetValue(product.Name);
        productElement.Element(CATEGORY).SetValue(product.Category);
        productElement.Element(COLOR).SetValue(product.Color);
        productElement.Element(PRODUCTION_DATE).SetValue(product.ProductionDate);
        productElement.Element(AGING_PERIOD).SetValue(product.AgingPeriod);
        productElement.Element(WINERY).SetValue(product.Winery);
        productElement.Element(DESCRIPTION).SetValue(product.Description);
        productElement.Element(SEASON).SetValue(product.Season);
        productElement.Element(AMOUNT).SetValue(product.Amount);
        productElement.Element(PRICE).SetValue(product.Price);
        SaveXml(productsList);
    }

    private Product XElementToProduct(XElement p)
    {
        return new Product(
            int.Parse(p.Element(ID).Value),
            p.Element(NAME)?.Value,
            p.Element(CATEGORY) != null ? (Category)Enum.Parse(typeof(Category), p.Element(CATEGORY).Value) : 0,
            p.Element(COLOR)?.Value,
            p.Element(PRODUCTION_DATE) != null ? DateTime.Parse(p.Element(PRODUCTION_DATE).Value) : DateTime.MinValue,
            p.Element(AGING_PERIOD) != null ? int.Parse(p.Element(AGING_PERIOD).Value) : 0,
            p.Element(WINERY)?.Value,
            p.Element(DESCRIPTION)?.Value,
            p.Element(SEASON) != null ? (Season)Enum.Parse(typeof(Season), p.Element(SEASON).Value) : 0,
            p.Element(AMOUNT) != null ? int.Parse(p.Element(AMOUNT).Value) : 1,
            p.Element(PRICE) != null ? double.Parse(p.Element(PRICE).Value) : 0
        );
    }
}
