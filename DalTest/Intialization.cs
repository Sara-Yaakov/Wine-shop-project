

namespace DalTest;
using DO;
using DalApi;


public static class Intialization
{
    public static IProduct p_dalProduct;
    public static ICustomer c_dalCustomer;
    public static ISale s_dalSale;
    
    public static void Intialize(ICustomer c,IProduct p, ISale s)
    {
        p_dalProduct = p;
        c_dalCustomer = c;
        s_dalSale = s;
        CreateCustomers();
        CreateProducts();
        CreateSales();
    }

    public static List<int> ids = new();
    public static void CreateProducts()
    {
        ids.Add(p_dalProduct.Create(new Product(0, "Goldstar Lager", Category.beer, "dark", new DateTime(2024, 2, 1), 5, "Goldstar Brewery", "Classic Israeli dark lager beer", Season.summer, 3, 550)));
        ids.Add(p_dalProduct.Create(new Product(0, "Maccabee Light", Category.beer, "light", new DateTime(2024, 1, 15), 4, "Tempo Brewery", "Light and refreshing lager beer", Season.summer, 3, 520)));
        ids.Add(p_dalProduct.Create(new Product(0, "Baileys Irish Cream", Category.liqueur, "cream", new DateTime(2023, 11, 10), 17, "Baileys", "Cream liqueur with chocolate and vanilla notes", Season.winter, 4, 980)));
        ids.Add(p_dalProduct.Create(new Product(0, "Cointreau Orange Liqueur", Category.liqueur, "orange", new DateTime(2023, 9, 5), 40, "Cointreau", "Premium orange-flavored liqueur", Season.fall, 5, 1150)));
        ids.Add(p_dalProduct.Create(new Product(0, "Moet & Chandon Brut Imperial", Category.champagne, "sparkling", new DateTime(2023, 12, 1), 12, "Moet & Chandon", "Dry and elegant champagne with fine bubbles", Season.spring, 5, 2100)));
        ids.Add(p_dalProduct.Create(new Product(0, "Veuve Clicquot Brut", Category.champagne, "sparkling", new DateTime(2023, 10, 20), 12, "Veuve Clicquot", "Rich and balanced champagne", Season.spring, 5, 2200)));
        ids.Add(p_dalProduct.Create(new Product(0, "Chenin Blanc 2024", Category.wine, "white", new DateTime(2024, 3, 1), 8, "Barkan Winery", "Fresh and aromatic Chenin Blanc with citrus and green apple notes", Season.spring, 4, 850)));
        ids.Add(p_dalProduct.Create(new Product(0, "Cabernet Sauvignon Reserve 2021", Category.wine, "red", new DateTime(2021, 10, 15), 14, "Carmel Winery", "Full-bodied Cabernet Sauvignon aged in oak barrels", Season.winter, 5, 1200)));
        ids.Add(p_dalProduct.Create(new Product(0, "Merlot Galilee 2022", Category.wine, "red", new DateTime(2022, 9, 20), 13, "Dalton Winery", "Smooth Merlot with notes of plum and cherry", Season.winter, 4, 980)));
        ids.Add(p_dalProduct.Create(new Product(0, "Sauvignon Blanc 2023", Category.wine, "white", new DateTime(2023, 4, 10), 12, "Tabor Winery", "Crisp Sauvignon Blanc with tropical fruit aromas", Season.spring, 4, 890)));
        ids.Add(p_dalProduct.Create(new Product(0, "Syrah Upper Galilee 2021", Category.wine, "red", new DateTime(2021, 11, 5), 14, "Recanati Winery", "Spicy and rich Syrah with black pepper and dark fruit", Season.winter, 5, 1350)));
        ids.Add(p_dalProduct.Create(new Product(0, "Rose Mediterranean 2023", Category.wine, "rose", new DateTime(2023, 5, 18), 11, "Yarden Winery", "Light and refreshing rose perfect for warm days", Season.summer, 3, 750)));
        ids.Add(p_dalProduct.Create(new Product(0, "Gewurztraminer 2022", Category.wine, "white", new DateTime(2022, 6, 30), 12, "Golan Heights Winery", "Aromatic wine with floral and lychee notes", Season.summer, 4, 920)));
    }
    public static void CreateSales()
    {
        s_dalSale.Create(new Sale(0, ids[2], 4, 850, false, new DateTime(2025, 3, 1), new DateTime(2025, 3, 31)));
        s_dalSale.Create(new Sale(0, ids[0], 3, 750, false, new DateTime(2025, 1, 1), new DateTime(2025, 1, 31)));
        s_dalSale.Create(new Sale(0, ids[1], 6, 1050, true, new DateTime(2025, 2, 1), new DateTime(2025, 2, 28)));
        s_dalSale.Create(new Sale(0, ids[3], 2, 790, true, new DateTime(2025, 4, 1), new DateTime(2025, 4, 30)));
        s_dalSale.Create(new Sale(0, ids[4], 6, 1200, true, new DateTime(2025, 5, 1), new DateTime(2025, 5, 31)));
        s_dalSale.Create(new Sale(0, ids[5], 3, 650, false, new DateTime(2025, 6, 1), new DateTime(2025, 6, 30)));
        s_dalSale.Create(new Sale(0, ids[6], 5, 880, false, new DateTime(2025, 7, 1), new DateTime(2025, 7, 31)));


    }

    public static void CreateCustomers()
    {
        c_dalCustomer.Create(new Customer(0, "Dana Levi", "12 Herzl St, Tel Aviv", "050-1234567", true));
        c_dalCustomer.Create(new Customer(1, "Amit Cohen", "8 Ben Gurion Ave, Ramat Gan", "052-2345678", false));
        c_dalCustomer.Create(new Customer(2, "Noa Friedman", "25 Dizengoff St, Tel Aviv", "054-3456789", true));
        c_dalCustomer.Create(new Customer(3, "Eyal Shapiro", "3 HaNassi St, Haifa", "053-4567890", false));
        c_dalCustomer.Create(new Customer(4, "Yael Katz", "17 Weizmann St, Kfar Saba", "050-5678901", true));
        c_dalCustomer.Create(new Customer(5, "Omer Rosen", "9 Rothschild Blvd, Tel Aviv", "052-6789012", false));
        c_dalCustomer.Create(new Customer(6, "Shira Gold", "4 Arlozorov St, Netanya", "054-7890123", true));
        c_dalCustomer.Create(new Customer(7, "Lior Ben David", "22 Jabotinsky St, Petah Tikva", "053-8901234", false));
        c_dalCustomer.Create(new Customer(8, "Maya Azulay", "6 Hillel St, Jerusalem", "050-9012345", true));

    }

}
