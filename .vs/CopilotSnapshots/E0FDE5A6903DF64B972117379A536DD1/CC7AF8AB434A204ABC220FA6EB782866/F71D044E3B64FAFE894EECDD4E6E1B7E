
using DalApi;
using DO;

namespace Dal;

static public class DataSource
{

    static internal List<Customer?> customers = new(); 
    static internal List<Product?> products = new();
    static internal List<Sale?> sales =new();

    static internal class Config
    {
        internal const int minSalesId=3000;
        private static int runningSalesId= minSalesId;
        public static int CurrentRunningSalesId { get { return runningSalesId++; } }


        internal const int minProductsId = 1000;
        private static int runningProducts = minProductsId;
        public static int CurrentRunningProductsId { get { return runningProducts++; } }
    }

}
