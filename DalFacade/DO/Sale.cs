using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    //sale class: each sale has unique id,product id,required amount,price after discount,
    //flag that used to know if the sale is for club members only,
    //the start date and end the date of the sale
    public record Sale(
        int Id,
        int ProductId,
        int RequiredAmount,
        int PriceAfterDiscount,
        bool IsForClubMembersOnly,
        DateTime StartDate,
        DateTime EndDate)
    {
        public Sale():this(0,0,1,0,false,DateTime.Now,DateTime.Now) { }
    }
}
