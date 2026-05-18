using System.Collections;
using System.Reflection;
using System.Text;

namespace BO;

internal static class Tools
{

    public static string ToStringProperty(this object obj, int indent = 0)
    {
        if (obj == null)
            return "null";

        StringBuilder result = new StringBuilder();
        string indentStr = new string(' ', indent);

        foreach (var prop in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            object value = prop.GetValue(obj);


            if (value == null)
            {
                result.AppendLine($"{indentStr}{prop.Name}: null");
                continue;
            }


            if (value is string || value.GetType().IsPrimitive)
            {
                result.AppendLine($"{indentStr}{prop.Name}: {value}");
            }

            else if (value is IEnumerable enumerable && !(value is string))
            {
                result.AppendLine($"{indentStr}{prop.Name}:");

                foreach (var item in enumerable)
                {
                    if (item == null)
                    {
                        result.AppendLine($"{indentStr}  - null");
                    }

                    else if (item is string || item.GetType().IsPrimitive)
                    {
                        result.AppendLine($"{indentStr}  - {item}");
                    }

                    else
                    {
                        result.AppendLine($"{indentStr}  - ");
                        result.Append(ToStringProperty(item, indent + 4));
                    }
                }
            }

            else
            {
                result.AppendLine($"{indentStr}{prop.Name}:");
                result.Append(ToStringProperty(value, indent + 4));
            }
        }

        return result.ToString();
    }

    public static BO.Customer convertDOCustomerToBOCustomer(this DO.Customer customer)
    {
        return new BO.Customer
        {
            Id = customer.Id,
            Name = customer.Name,
            Address = customer.Address,
            PhoneNumber = customer.PhoneNumber,
            IsClubMember = customer.IsClubMember
        };
    }

    public static BO.Product convertDOProductToBOProduct(this DO.Product product)
    {
        return new BO.Product
        {
            Id = product.Id,
            Name = product.Name,
            Category = (BO.Enums.Category)product.Category,
            Color = product.Color,
            ProductionDate = product.ProductionDate,
            AgingPeriod = product.AgingPeriod,
            Winery = product.Winery,
            Description = product.Description,
            Season = (BO.Enums.Season)product.Season,
            Amount = product.Amount,
            Price = product.Price,


        };
    }

    public static BO.Sale convertDOSaleToBOSale(this DO.Sale sale)
    {
        return new BO.Sale
        {
            Id = sale.Id,
            ProductId = sale.ProductId,
            RequiredAmount = sale.RequiredAmount,
            PriceAfterDiscount = sale.PriceAfterDiscount,
            IsForClubMembersOnly = sale.IsForClubMembersOnly,
            StartDate = sale.StartDate,
            EndDate = sale.EndDate,
        };
    }


    public static DO.Customer convertBOCustomerToDOCustomer(this BO.Customer customer)
    {
        return new DO.Customer
        {
            Id = customer.Id,
            Name = customer.Name,
            Address = customer.Address,
            PhoneNumber = customer.PhoneNumber,
            IsClubMember = customer.IsClubMember
        };
    }

    public static DO.Product convertBOProductToDOProduct(this BO.Product product)
    {
        return new DO.Product 
        {
            Id = product.Id,
            Name = product.Name,
            Category = (DO.Category)product.Category,
            Color = product.Color,
            ProductionDate = product.ProductionDate,
            AgingPeriod = product.AgingPeriod,
            Winery = product.Winery,
            Description = product.Description,
            Season = (DO.Season)product.Season,
            Amount = product.Amount,
            Price = product.Price
        };
    }

    public static DO.Sale convertBOSaleToDOSale(this BO.Sale sale)
    {
        return new DO.Sale
        {
            Id = sale.Id,
            ProductId = sale.ProductId,
            RequiredAmount = sale.RequiredAmount,
            PriceAfterDiscount = sale.PriceAfterDiscount,
            IsForClubMembersOnly = sale.IsForClubMembersOnly,
            StartDate = sale.StartDate,
            EndDate = sale.EndDate,
        };
    }




}
