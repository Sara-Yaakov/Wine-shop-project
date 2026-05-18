using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DalXml
{
    internal static class Config
    {
        private static string configurationFileName = "../xml/data-config.xml";
        public static int ProductNum
        {
            get
            {
                XElement productXml = XElement.Load(configurationFileName);
                XElement curProdNum = productXml.Element("ProductNum");
                int curId = int.Parse(curProdNum.Value);
                curProdNum.SetValue(curId + 1);
                productXml.Save(configurationFileName);
                return curId;
            }
        }
        public static int SaleNum
        {
            get
            {
                XElement saleXml = XElement.Load(configurationFileName);
                XElement curSaleNum = saleXml.Element("SaleNum");
                int num = int.Parse(curSaleNum.Value);
                curSaleNum.SetValue(num + 1);
                saleXml.Save(configurationFileName);
                return num;
            }
        }
    }
}
