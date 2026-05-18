using Dal;
using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalXml
{
    public sealed class DalXml : IDal
    {
        private static DalXml instance { get; } = new DalXml();
        public static DalXml Instance { get { return instance; } }
        private DalXml()
        {

        }
        public ICustomer Customer => new CustomerImplementation();

        public ISale Sale => new SaleImplementation();

        public IProduct Product => new ProductImplementation();
    }
}
