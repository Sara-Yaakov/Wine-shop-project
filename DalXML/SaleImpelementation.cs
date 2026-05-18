using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Dal.DalExceptions;

namespace Dal;

internal class SaleImplementation : ISale
{
    const string SALES_FILE_PATH = "../xml/sales.xml";
    private List<Sale> LoadList()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Sale>));

        if (!File.Exists(SALES_FILE_PATH))
            return new List<Sale>();

        using StreamReader sr = new StreamReader(SALES_FILE_PATH);
        return serializer.Deserialize(sr) as List<Sale> ?? new List<Sale>();
    }
    private void SaveList(List<Sale> sales)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Sale>));
        using StreamWriter sw = new StreamWriter(SALES_FILE_PATH);
        serializer.Serialize(sw, sales);
    }
    public int Create(Sale sale)
    {
        int curId = DalXml.Config.SaleNum;
        Sale newSale = sale with { Id = curId };
        List<Sale> salesList= LoadList();
        salesList.Add(newSale);
        SaveList(salesList);
        return newSale.Id;
    }

    public void Delete(int id)
    {
        List<Sale> salesList= LoadList();
        var saleToDelete = salesList.SingleOrDefault(s => s.Id == id);
        if (saleToDelete==null)
            throw new DalIdNotFoundException("Sale deleting/updating ended with an error, the id is not exists");
        salesList.Remove(saleToDelete);
        SaveList(salesList);
    }

    public Sale? Read(int id)
    {
        List<Sale> salesList= LoadList();
        var saleToRead = salesList.SingleOrDefault(s => s.Id == id);
        if (saleToRead == null)
            throw new DalIdNotFoundException("Sale was not in the list");
        return saleToRead;
    }

    public Sale? Read(Func<Sale, bool> filter)
    {
        List<Sale> salesList= LoadList();
        var saleToRead = salesList.FirstOrDefault(filter);
        if (saleToRead == null)
            throw new DalIdNotFoundException("No sale found matching the filter");
        return saleToRead;
    }

    public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
    {
        List<Sale> salesList= LoadList();
        return filter == null
             ? salesList.ToList()
             : salesList.Where(filter).ToList();
    }

    public void Update(Sale sale)
    {
        List<Sale> salesList= LoadList();
        var existingSaleIndex = salesList.FindIndex(s => s.Id == sale.Id);
        if (existingSaleIndex == -1)
            throw new DalIdNotFoundException("Sale is not in the list");
        salesList[existingSaleIndex] = sale;
        SaveList(salesList);
    }
}
