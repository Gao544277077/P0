using System;
using System.Collections.Generic;
using Entities;


namespace DAL
{
    public class CustomerDAL
    {
        public static List<Customer> customerList = new List<Customer>();
        public void Create(Customer cust)
        {
            customerList.Add(cust);

        }
        public void CreateAccount(Customer cust, Acc newAcc)
        {
            cust.AccList.Add(newAcc);

        }

        public Acc GetAccount(int id)
        {
            try
            {
                // Connect to DB, search for record with matching id.
                foreach (Customer cust in customerList)
                {



                    if (cust.Id == id)
                    {
                        Console.WriteLine("choose a Account");
                        string accountnum = Console.ReadLine();
                        //throw new Exception("Cannot connect to the Database.");
                        foreach (Acc acc in cust.AccList)

                            if (acc.Accountnum == accountnum)
                            {
                                return acc;
                            }

                    }
                }

            }
            catch (Exception)
            {
                // Log the details of the exception.
                return null;

            }
            return null;

        }
        public Customer GetCustomer(int id)
        {
            try
            {
                // Connect to DB, search for record with matching id.
                foreach (Customer cust in customerList)
                {



                    if (cust.Id == id)
                    {

                        //throw new Exception("Cannot connect to the Database.");
                        return cust;

                        //throw new Exception("This is my custom exception.");
                    }

                }

            }
            catch (Exception)
            {
                // Log the details of the exception.
                return null;

            }
            return null;

        }
        public Customer Get(int id)
        {
            try
            {
                // Connect to DB, search for record with matching id.
                Customer cust = new Customer()
                {
                    Id = id,
                    Firstname = "",
                    Lastname = ""
                };

                //throw new Exception("Cannot connect to the Database.");
                return cust;
                //throw new Exception("This is my custom exception.");
            }
            catch (Exception)
            {
                // Log the details of the exception.
                return null;

            }

        }

        public List<Customer> GetAll()
        {
            return customerList;
        }
    }
}
