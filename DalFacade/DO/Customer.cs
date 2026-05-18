using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    //customer class: each customer has id, name, adress,
    //phone number and flag that used to know if the customer is a club member
    public record Customer(
        int Id,
        string Name,
        string Address,
        string PhoneNumber,
        bool IsClubMember)
    {
        public Customer() : this(0, "", "", "", false) { }
    }
}
