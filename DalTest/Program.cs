

using Dal;
using DalApi;
using DO;
namespace DalTest;


internal class Program
{

    private static readonly IDal s_dal = DalApi.Factory.Get;

    private static Category ParseCategory(string season)
    {
        switch (season)
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
        Console.WriteLine(
            "for customers press 1\nfor products press 2\n" +
            "for sales press 3\n" +
            "to exit press any other key"
            );

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
        while (choose >= 1 && choose <= 5)
        {


            switch (obj, choose)
            {
                case ("customer", 1): CreateCustomer(); break;
                case ("customer", 2): Delete<Customer>(s_dal.Customer); break;
                case ("customer", 3): UpdateCustomer(); break;
                case ("customer", 4): Read<Customer>(s_dal.Customer); break;
                case ("customer", 5): ReadAll<Customer>(s_dal.Customer); break;

                case ("product", 1): CreateProduct(); break;
                case ("product", 2): Delete<Product>(s_dal.Product); break;
                case ("product", 3): UpdateProduct(); break;
                case ("product", 4): Read<Product>(s_dal.Product); break;
                case ("product", 5): ReadAll<Product>(s_dal.Product); break;

                case ("sale", 1): CreateSale(); break;
                case ("sale", 2): Delete<Sale>(s_dal.Sale); break;
                case ("sale", 3): UpdateSale(); break;
                case ("sale", 4): Read<Sale>(s_dal.Sale); break;
                case ("sale", 5): ReadAll<Sale>(s_dal.Sale); break;

            }

            Console.Write("\x1b[48;2;128;0;32m");
            Console.Clear();
            Console.WriteLine("what do you want to do?");
            Console.WriteLine("create new {0} ---1\ndelete {0} ---2\nupdate {0} ---3\nread {0} ---4\nread all {0}s ---5\npress any other key to return to main menu", obj);
            if (!int.TryParse(Console.ReadLine(), out choose))
                Menu();
        }
        Menu();
    }


    public static void CreateCustomer()
    {
        Console.WriteLine("-----creating customer----");
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
        s_dal.Customer.Create(new Customer(id, name, address, phoneNumber, isClubMember));
    }

    public static void UpdateCustomer()
    {
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
        s_dal.Customer.Create(new Customer(id, name, address, phoneNumber, isClubMember));
    }



    public static void CreateProduct()
    {

        Console.WriteLine("-----creating product----");
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
        s_dal.Product.Create(new Product(0, name, cat, color, pd, ap, winery, description, seas, amount, price));

    }

    public static void UpdateProduct()
    {
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
        s_dal.Product.Update(p);

    }

    public static void CreateSale()
    {
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
        s_dal.Sale.Create(new Sale(0, pi, ra, pad, ifcm, sd, ed));
    }

    public static void UpdateSale()
    {

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
        s_dal.Sale.Update(s);
    }


    public static void ReadAll<T>(ICrud<T> icrud)
    {
        List<T> l = icrud.ReadAll();
        foreach (T t in l)
        {
            Console.WriteLine(t);
        }
        Console.WriteLine("press any key to exit");
        Console.ReadLine();
    }
    public static void Read<T>(ICrud<T> icrud)
    {
        Console.WriteLine("insert id");
        if (!int.TryParse(Console.ReadLine(), out int id)) return;
        Console.WriteLine(icrud.Read(id));
        Console.WriteLine("press any key to exit");
        Console.ReadLine();
    }
    public static void Delete<T>(ICrud<T> icrud)
    {
        Console.WriteLine("insert id");
        if (!int.TryParse(Console.ReadLine(), out int id)) return;
        icrud.Delete(id);
        Console.WriteLine("the deleting is over, press any key to exit");
        Console.ReadLine();
    }
    static void Main(string[] args)
    {
        try
        {
            Intialization.Initialize();
            Menu();
        }
        catch (Exception ex)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine("An err  or occurred: " + ex.Message);
        }
    }

}
