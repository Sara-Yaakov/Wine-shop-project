namespace DalApi;
using DO;
using System;
using System.Collections.Generic;

public interface ICustomer : ICrud<Customer>
{
    //מה הענין של הפונקציה הזאת אם יש את ההצהרה ב-CRUD
    //List<Customer> ReadAll(Func<Customer, bool>? filter);

   //מה המטרה של הפרמטר V 
   // List<Customer> ReadAll();

    //object ReadAll(bool v, Func<Customer, bool>? filter);
    //List<Customer> ReadAll(bool v, Func<global::BO.Customer, bool>? filter);
}
