using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dal
{
    internal static class Config
    {
        // Folder of the XML data files: the "xml" folder that holds dal-config.xml,
        // searched upward from the app folder and then from the working directory.
        internal static readonly string XmlDirectory = FindXmlDirectory();
        private static string configurationFileName = Path.Combine(XmlDirectory, "data-config.xml");

        private static string FindXmlDirectory()
        {
            foreach (string start in new[] { AppContext.BaseDirectory, Directory.GetCurrentDirectory() })
            {
                DirectoryInfo? dir = new DirectoryInfo(start);
                for (int i = 0; i < 6 && dir != null; i++, dir = dir.Parent)
                {
                    string candidate = Path.Combine(dir.FullName, "xml");
                    if (File.Exists(Path.Combine(candidate, "dal-config.xml")))
                        return candidate;
                }
            }
            return "../xml"; // previous behavior when nothing is found
        }

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
