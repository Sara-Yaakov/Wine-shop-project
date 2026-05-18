using BlApi;
using BO;
using DalApi;
using DO;
using System.Runtime.Intrinsics.Arm;

namespace BlImplementation;

internal class OrderImplementation : IOrder
{
    public void AddProductToOrder(Order order, int productId, int amount)
    {
        bool isProductInOrder = false;
        DO.Product dalProduct = Factory.Get.Product.Read(productId);
        BO.Product product = new BO.Product
        {
            Id = dalProduct.Id,
            Name = dalProduct.Name,
            Category = dalProduct.Category,
            Color = dalProduct.Color,
            ProductionDate = dalProduct.ProductionDate,
            AgingPeriod = dalProduct.AgingPeriod,
            Winery = dalProduct.Winery,
            Description = dalProduct.Description,
            Season = dalProduct.Season,
            Amount = dalProduct.Amount,
            Price = dalProduct.Price
        };

        if (amount > product.Amount)
        {
            throw new Exception("there are only " + product.Amount + " in the stock");
        }


        foreach (ProductInOrder p in order.Products)
        {
            if (p.ProductId == productId)
            {
                if (p.Amount + amount < 0)
                    throw new Exception("you are trying to download non-existent products");
                p.Amount += amount;
                SearchSaleForProduct(p, order.IsClubMember);
                CalcTotalPriceForProduct(p);
                isProductInOrder = true;
            }
        }
        if (!isProductInOrder)
        {
            if (amount < 0)
                throw new Exception("you are trying to download non-existent products");
            ProductInOrder pio = new ProductInOrder
            {
                ProductId = product.Id,
                Amount = product.Amount,
                ProductName = product.Name,
                BasicPrice = product.Price,
            };
            SearchSaleForProduct(pio, order.IsClubMember);
            CalcTotalPriceForProduct(pio);
            order.Products.Add(pio);
        }
        CalcTotalPrice(order);

    }

    public void CalcTotalPrice(Order order)
    {
        double totalPrice = 0;
        foreach (ProductInOrder pio in order.Products)
        {
            totalPrice += pio.FinalPrice;
        }
    }

    public void CalcTotalPriceForProduct(ProductInOrder productInOrder)
    {
        List<SaleInProduct> saleInProducts = new List<SaleInProduct>();
        double totalPrice = 0;
        int restAmount = productInOrder.Amount;
        productInOrder.SalesOfProduct.ForEach(sop =>
        {
            if (sop.ProductAmount < restAmount)
            {
                totalPrice += restAmount / sop.ProductAmount * sop.Price;
                restAmount -= restAmount % sop.ProductAmount;
            }
            saleInProducts.Add(sop);
        });
        totalPrice += restAmount * productInOrder.BasicPrice;
        productInOrder.FinalPrice = totalPrice;
        productInOrder.SalesOfProduct = saleInProducts;
    }

    public void SearchSaleForProduct(ProductInOrder productInOrder, bool isCustomerClubMember)
    {
        List<DO.Sale> doSales;
        if (isCustomerClubMember == true)
        {
            doSales = Factory.Get.Sale.ReadAll(
                true,
                s => s.StartDate < DateTime.Now &&
                    s.EndDate > DateTime.Now &&
                    s.RequiredAmount <= productInOrder.Amount);
        }
        else
        {
            doSales = Factory.Get.Sale.ReadAll(
                true,
                s => s.StartDate < DateTime.Now &&
                    s.EndDate > DateTime.Now &&
                    s.RequiredAmount <= productInOrder.Amount &&
                    s.IsForClubMembersOnly == false);
        }

        productInOrder.SalesOfProduct = doSales
            .OrderBy(s => s.PriceAfterDiscount)
            .Select(s => new SaleInProduct
            {
                SaleId = s.Id,
                ProductId = s.ProductId,
                ProductAmount = s.RequiredAmount,
                Price = s.PriceAfterDiscount,
                IsForClubMembersOnly = s.IsForClubMembersOnly

            })
            .ToList();
    }

    public void DoOrder(Order order)
    {
        foreach ( ProductInOrder p in order.Products)
        {
            DO.Product dalProduct = Factory.Get.Product.Read(p.ProductId);
            DO.Product updated = dalProduct with { Amount = dalProduct.Amount - p.Amount };
            Factory.Get.Product.Update(updated);
        }

    }

    public int Create(Order item)
    {
        throw new NotImplementedException("no orders saved");
    }

    public void Delete(int id)
    {
        throw new NotImplementedException("no orders saved");
    }

    public Order? Read(int id)
    {
        throw new NotImplementedException("no orders saved");
    }

    public Order? Read(Func<Order, bool> filter)
    {
        throw new NotImplementedException("no orders saved");
    }

    public List<Order> ReadAll(Func<Order, bool>? filter = null)
    {
        throw new NotImplementedException("no orders saved");
    }

    public void Update(Order item)
    {
        throw new NotImplementedException("no orders saved");
    }
}
