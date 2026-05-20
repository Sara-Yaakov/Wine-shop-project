using BlApi;
using static BO.Tools;
using static BO.BlException;
using DalApi;
using System.Runtime.Intrinsics.Arm;

namespace BlImplementation;

internal class OrderImplementation : IOrder
{
    private DalApi.IDal _dal = DalApi.Factory.Get;
    public void AddProductToOrder(BO.Order order, int productId, int amount)
    {
        bool isProductInOrder = false;
        BO.Product product=_dal.Product.Read(productId).convertDOProductToBOProduct();

        if (amount > product.Amount)
        {
            throw new BlNegetiveAmountInOrder("there are only " + product.Amount + " in the stock");
        }


        foreach (BO.ProductInOrder p in order.Products)
        {
            if (p.ProductId == productId)
            {
                if (p.Amount + amount < 0)
                    throw new BlNoProductInStock("you are trying to download non-existent products");
                p.Amount += amount;
                SearchSaleForProduct(p, order.IsClubMember);
                CalcTotalPriceForProduct(p);
                isProductInOrder = true;
            }
        }
        if (!isProductInOrder)
        {
            if (amount < 0)
                throw new BlNoProductInStock("you are trying to download non-existent products");
            BO.ProductInOrder pio = new BO.ProductInOrder
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

    public void CalcTotalPrice(BO.Order order)
    {
        double totalPrice = 0;
        foreach (BO.ProductInOrder pio in order.Products)
        {
            totalPrice += pio.FinalPrice;
        }
    }

    public void CalcTotalPriceForProduct(BO.ProductInOrder productInOrder)
    {
        List<BO.SaleInProduct> saleInProducts = new List<BO.SaleInProduct>();
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

    public void SearchSaleForProduct(BO.ProductInOrder productInOrder, bool isCustomerClubMember)
    {
        List<BO.Sale> sales;
        if (isCustomerClubMember == true)
        {
            sales = _dal.Sale.ReadAll(
                s => s.StartDate < DateTime.Now &&
                    s.EndDate > DateTime.Now &&
                    s.RequiredAmount <= productInOrder.Amount)
                    .Select(s=>s.convertDOSaleToBOSale())
                    .ToList();
        }
        else
        {
            sales = _dal.Sale.ReadAll(
                s => s.StartDate < DateTime.Now &&
                    s.EndDate > DateTime.Now &&
                    s.RequiredAmount <= productInOrder.Amount &&
                    s.IsForClubMembersOnly == false)
                    .Select(s => s.convertDOSaleToBOSale())
                    .ToList(); 
        }

        productInOrder.SalesOfProduct = sales
            .OrderBy(s => s.PriceAfterDiscount)
            .Select(s => new BO.SaleInProduct
            {
                SaleId = s.Id,
                ProductId = s.ProductId,
                ProductAmount = s.RequiredAmount,
                Price = s.PriceAfterDiscount,
                IsForClubMembersOnly = s.IsForClubMembersOnly

            })
            .ToList();
    }

    public void DoOrder(BO.Order order)
    {
        foreach ( BO.ProductInOrder p in order.Products)
        {
            BO.Product prod = _dal.Product.Read(p.ProductId).convertDOProductToBOProduct();
            prod.Amount -= p.Amount;
            _dal.Product.Update(prod.convertBOProductToDOProduct());
        }

    }

}
