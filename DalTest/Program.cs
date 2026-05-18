
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using Dal;
using DalApi;
using DO;
using static Dal.DalExceptions;

namespace DalTest
{
    internal class Program
    {
        private static ICustomer c_dalCustomer = new CustomerImplementation();
        private static ISale s_dalSale = new SaleImplementation();
        private static IProduct p_dalProduct = new ProductImplementation();

        private static Category ParseCategory(string season)
        {
            switch(season)
            {
                case "beer": return Category.beer;
                case "champagne": return Category.champagne;
                case "liqueur": return Category.liqueur;
            }
            return Category.wine;
        }
        private static Season ParseSeason(string category)
        {
            switch (category)
            {
                case "winter": return Season.winter;
                case "spring": return Season.spring;
                case "fall": return Season.fall;
                case "summer": return Season.summer;
            }
            return Season.all;
        }
        public static void Menu()
        {
            Console.Write("\x1b[48;2;35;51;21m");
            Console.Clear();
            Console.WriteLine("for customers press 1\nfor products press 2\nfor sales press 3\nto exit press any other key");
            int choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1: SubMenu("customer"); break;
                case 2: SubMenu("product"); break;
                case 3: SubMenu("sale"); break;
                default: return;
            }
        }

        public static void SubMenu(string obj)
        {
            Console.Write("\x1b[48;2;128;0;32m");
            Console.Clear();
            Console.WriteLine("what do you want to do?");
            Console.WriteLine("create new {0} ---1\ndelete {0} ---2\nupdate {0} ---3\nread {0} ---4\nread all {0}s ---5\npress any other key to return to main menu", obj);
            if (!int.TryParse(Console.ReadLine(), out int choose))
                return;

            switch (obj, choose)
            {
                case ("customer", 1): CreateCustomer(); break;
                case ("customer", 2): DeleteCustomer(); break;
                case ("customer", 3): UpdateCustomer(); break;
                case ("customer", 4): ReadCustomer(); break;
                case ("customer", 5): ReadAllCustomers(); break;

                case ("product", 1): CreateProduct(); break;
                case ("product", 2): DeleteProduct(); break;
                case ("product", 3): UpdateProduct(); break;
                case ("product", 4): ReadProduct(); break;
                case ("product", 5): ReadAllProducts(); break;

                case ("sale", 1): CreateSale(); break;
                case ("sale", 2): DeleteSale(); break;
                case ("sale", 3): UpdateSale(); break;
                case ("sale", 4): ReadSale(); break;
                case ("sale", 5): ReadAllSales(); break;

            }
        }


        public static void CreateCustomer() {
            Console.WriteLine("-----creating customer----");
            Console.WriteLine("insert id:");
            if(!int.TryParse(Console.ReadLine(), out int id))return;
            Console.WriteLine("insert name");
            string name=Console.ReadLine();
            Console.WriteLine("insert address");
            string address=Console.ReadLine();
            Console.WriteLine("insert phone number");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("do you want to be a club member? true/false");
            bool isClubMember=bool.Parse(Console.ReadLine());
            c_dalCustomer.Create(new Customer(id, name, address, phoneNumber, isClubMember));
            Menu();
        }
        public static void DeleteCustomer() {
            Console.WriteLine("---- deleting customer----");
            Console.WriteLine("insert customer id");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;
            c_dalCustomer.Delete(id);
            Menu();

        }
        public static void UpdateCustomer() {
            Console.WriteLine("----updating customer----");
            Console.WriteLine("insert id:");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;
            Console.WriteLine("insert name");
            string name = Console.ReadLine();
            Console.WriteLine("insert address");
            string address = Console.ReadLine();
            Console.WriteLine("insert phone number");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("do you want to be a club member? true/false");
            bool isClubMember = bool.Parse(Console.ReadLine());
            c_dalCustomer.Create(new Customer(id, name, address, phoneNumber, isClubMember));
            Menu();
        }
        public static void ReadCustomer() {
            Console.WriteLine("----reading customer----");
            Console.WriteLine("insert customer id");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;
            Customer c=c_dalCustomer.Read(id);
            Console.WriteLine(c);
            Console.WriteLine("press any key and return to the menu");
            Console.ReadLine();
            Menu();

        }
        public static void ReadAllCustomers() {
            Console.WriteLine("----reading all customers----");
            List<Customer> lc = c_dalCustomer.ReadAll();
            foreach (Customer c in lc)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("press any key and return to the menu");
            Console.ReadLine();
            Menu();
        }

        public static void CreateProduct() {

            Console.WriteLine("-----creating product----");
            Console.WriteLine("insert name");
            string name = Console.ReadLine();
            Console.WriteLine("insert category: wine,beer,champagne,liqueur");
            string category=Console.ReadLine();
            Console.WriteLine("insert color");
            string color = Console.ReadLine();
            Console.WriteLine("insert production date");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime pd)) ;
            Console.WriteLine("insert aging period");
            if (!int.TryParse(Console.ReadLine(), out int ap)) return;
            Console.WriteLine("insert winery");
            string winery=Console.ReadLine();
            Console.WriteLine("insert description");
            string description=Console.ReadLine();
            Console.WriteLine("insert season");
            string season = Console.ReadLine();
            Console.WriteLine("insert amount");
            if (!int.TryParse(Console.ReadLine(), out int amount)) return;
            Console.WriteLine("insert price");
            if (!double.TryParse(Console.ReadLine(), out double price)) return;
            Category cat=ParseCategory(category);
            Season seas=ParseSeason(season);
            p_dalProduct.Create(new Product(0, name, cat, color, pd, ap, winery, description, seas, amount, price));
            Menu();

        }
        public static void DeleteProduct() {
            Console.WriteLine("---- deleting product----");
            Console.WriteLine("insert product id");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;
            p_dalProduct.Delete(id);
            Menu();
        }
        public static void UpdateProduct() {
            Console.WriteLine("-----updating product----");
            Console.WriteLine("insert id");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;
            Console.WriteLine("insert name");
            string name = Console.ReadLine();
            Console.WriteLine("insert category: wine,beer,champagne,liqueur");
            string category = Console.ReadLine();
            Console.WriteLine("insert color");
            string color = Console.ReadLine();
            Console.WriteLine("insert production date");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime pd)) ;
            Console.WriteLine("insert aging period");
            if (!int.TryParse(Console.ReadLine(), out int ap)) return;
            Console.WriteLine("insert winery");
            string winery = Console.ReadLine();
            Console.WriteLine("insert description");
            string description = Console.ReadLine();
            Console.WriteLine("insert season");
            string season = Console.ReadLine();
            Console.WriteLine("insert amount");
            if (!int.TryParse(Console.ReadLine(), out int amount)) return;
            Console.WriteLine("insert price");
            if (!double.TryParse(Console.ReadLine(), out double price)) return;
            Category cat = ParseCategory(category);
            Season seas = ParseSeason(season);
            Product p = new Product(id, name, cat, color, pd, ap, winery, description, seas, amount, price);
            p_dalProduct.Update(p);
            Menu();

        }
        public static void ReadProduct() {
            Console.WriteLine("----reading product----");
            Console.WriteLine("insert product id");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;
            Product p= p_dalProduct.Read(id);
            Console.WriteLine(p);
            Console.WriteLine("press any key and return to the menu");
            Console.ReadLine();
            Menu();
        }
        public static void ReadAllProducts() {
            Console.WriteLine("----reading all products----");
            List<Product> lp = p_dalProduct.ReadAll();
            foreach (Product p in lp)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("press any key and return to the menu");
            Console.ReadLine();
            Menu();
        }

        public static void CreateSale() {
            Console.WriteLine("-----creating sale----");
            Console.WriteLine("insert product id");
            if (!int.TryParse(Console.ReadLine(), out int pi)) return;
            Console.WriteLine("insert required amount");
            if (!int.TryParse(Console.ReadLine(), out int ra)) return;
            Console.WriteLine("insert price after discount");
            if (!int.TryParse(Console.ReadLine(), out int pad)) return;
            Console.WriteLine("is the sale only for club members? true/false");
            bool ifcm = bool.Parse(Console.ReadLine());
            Console.WriteLine("insert the start date");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime sd)) ;
            Console.WriteLine("insert the end date");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime ed)) ;
            s_dalSale.Create(new Sale(0, pi, ra, pad, ifcm, sd, ed));
            Menu();
        }
        public static void DeleteSale() {
            Console.WriteLine("---- deleting sale----");
            Console.WriteLine("insert sale id");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;
            s_dalSale.Delete(id);
            Menu();

        }
        public static void UpdateSale() {

            Console.WriteLine("-----updating sale----");
            Console.WriteLine("insert id");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;
            Console.WriteLine("insert product id");
            if (!int.TryParse(Console.ReadLine(), out int pi)) return;
            Console.WriteLine("insert required amount");
            if (!int.TryParse(Console.ReadLine(), out int ra)) return;
            Console.WriteLine("insert price after discount");
            if (!int.TryParse(Console.ReadLine(), out int pad)) return;
            Console.WriteLine("is the sale only for club members? true/false");
            bool ifcm = bool.Parse(Console.ReadLine());
            Console.WriteLine("insert the start date");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime sd)) ;
            Console.WriteLine("insert the end date");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime ed)) ;
            Sale s = new Sale(id, pi, ra, pad, ifcm, sd, ed);
            s_dalSale.Update(s);
            Menu();
        }
        public static void ReadSale() {
            Console.WriteLine("----reading sale----");
            Console.WriteLine("insert sale id");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;
            Sale s=s_dalSale.Read(id);
            Console.WriteLine(s);
            Console.WriteLine("press any key and return to the menu");
            Console.ReadLine();
            Menu();
        }
        public static void ReadAllSales() {
            Console.WriteLine("----reading all sales----");
            List<Sale> ls = s_dalSale.ReadAll();
            foreach (Sale s in ls)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("press any key and return to the menu");
            Console.ReadLine();
            Menu();
        }

        static void Main(string[] args)
        {
            try
            {
                Intialization.Intialize(c_dalCustomer, p_dalProduct, s_dalSale);
                Menu();
            }
            catch(Exception ex) 
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor= ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

    }
}
