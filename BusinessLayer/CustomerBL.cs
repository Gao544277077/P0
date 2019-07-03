using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CustomerBL
    {

        Customer newCustomer = new Customer();
        CustomerDAL DAL = new CustomerDAL();
        public void Create()
        {
            try
            {
                newCustomer.Id = CustomerDAL.customerList.Count + 101;
                Console.Write("Enter the your First name: ");
                newCustomer.Firstname = Console.ReadLine();
                Console.Write("Enter the your Last name: ");
                newCustomer.Lastname = Console.ReadLine();
                DAL.Create(newCustomer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        public void openAcc(int id)
        {
            //foreach (Customer cust in CustomerDAL.customerList)
            //{
            try
            {
                Customer cust = DAL.GetCustomer(id);

                if (cust.Id == id)
                {

                    Console.WriteLine("1:Businness Acoount\n2:Checking Account");
                    int i = Convert.ToInt32(Console.ReadLine());
                    if (i == 1)
                    {
                        Acc a = new BusAcc();
                        a.id = cust.Id;
                        //Console.WriteLine("1");
                        a.Accountnum = "B12345" + cust.Id + cust.AccList.Count;
                        a.Amount = 0;
                        DAL.CreateAccount(cust, a);
                        //cust.customerList.Add(a);
                        Console.WriteLine("Your new account number is:  " + a.Accountnum);



                    }

                    else if (i == 2)
                    {
                        Acc a = new CheckAcc();
                        a.id = cust.Id;
                        a.Accountnum = "C12345" + cust.Id + cust.AccList.Count;
                        a.Amount = 0;
                        DAL.CreateAccount(cust, a);
                        Console.WriteLine("Your new account number is:  " + a.Accountnum);

                    }

                    else
                    {
                        throw new Exception();
                    }


                    getallacc(cust.Id);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void closeAcc(int id)
        {
            //List<Acc>AccList = getallacc(id);
            Customer cust = DAL.GetCustomer(id);
           
            Console.WriteLine("Enter the account number to remove this account:");
              string n = Console.ReadLine();
            //foreach (Acc a in AccList)
            //{
            cust.AccList.RemoveAll(x => x.Accountnum == n);
            //foreach (Acc a in cust.AccList) { 

            //if (a.Accountnum == n) {
            //        cust.AccList.Remove(a);
            //    }
            //}
            getallacc(id);
        }

        public bool trsansfer(Customer cust, double n, string a)
        {
            bool trans = false;
            try
            {
                foreach (Acc account in cust.AccList)
                {
                    if (account.Accountnum == a)
                    {
                        account.deposit(n);
                        trans = true;
                    }
                    //else
                    //{

                    //    //Console.WriteLine("Not this Account");
                    //    throw new Exception("Not this Account");
                    //}
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.StackTrace);
            }
            return trans;
        }


        public void Applyloan(int id)

        {
            try
            {
                Customer cust = DAL.GetCustomer(id);

                Loan P = new Loan();
                Console.WriteLine("enter the amount of loan:  ");
                double n = Convert.ToDouble(Console.ReadLine());
                n = Convert.ToDouble(n.ToString("#.##"));
                cust.PLI = true;
                payloanBL pbl = new payloanBL();
                Console.WriteLine("1 year plan:interest rate:10%  (1)\n 5 year plan(2):interest rate:15%\n other to main menu \n Enter a plan: ");
                int i = Convert.ToInt32(Console.ReadLine());
                if (i == 1)
                {
                    pbl.plan1(n);
                    P = pbl.plan1(n);
                    Console.WriteLine($"You have join the payloan plan 1\n Id: {cust.Id} - Firstname: {cust.Firstname} - Lastname: {cust.Lastname} -Monthlypay: {P.monthlypay}- Total loan amount: {P.loan}- Period: {P.period}");
                    cust.loanList.Add(P);
                    P.id = cust.loanList.Count;
                }
                else if (i == 2)
                {
                    pbl.plan2(n);
                    Console.WriteLine($"You have join the payloan plan 2\n Id: {cust.Id} - Firstname: {cust.Firstname} - Lastname: {cust.Lastname} -Monthlypay: {P.monthlypay}- Total loan amount: {P.loan}- Period: {P.period}");
                    cust.loanList.Add(P);
                    P.id = cust.loanList.Count;
                }
                else
                {
                    Console.WriteLine("not this plan,return to the main menu");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        public void payloan(int id)
        {
            try
            {
                Customer cust = DAL.GetCustomer(id);


                if (cust.PLI == false)
                {
                    Console.WriteLine("you don't apply personal loan.");
                }
                getallloan(cust.Id);

                Console.WriteLine("Enter the Loan Account number:");
                int n = Convert.ToInt32(Console.ReadLine()) - 1;
                Loan P = cust.loanList[n];
                Console.WriteLine("Choose a Account to pay loans");
                getallacc(cust.Id);
                Console.WriteLine($"Enter the SelectID to choose an account to pay the monthly payment {P.monthlypay}");
                n = Convert.ToInt32(Console.ReadLine()) - 1;
                cust.AccList[n].withdrawls(P.monthlypay);

                P.period = P.period - 1;
                P.pay = true;
                P.loan = P.loan - P.monthlypay;
                P.Expiredate = P.Expiredate.AddMonths(1);
                Console.WriteLine($"you have pay:  {P.monthlypay} of your {P.id} loan  and your remainder loan is {P.loan}");

                if (P.loan == 0)
                {
                    cust.PLI = false;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("you don't have this account.");
            }

        }

        public List<Acc> getallacc(int id)
        {

            Customer cust = DAL.GetCustomer(id);
            if (id == cust.Id)
            {
                {
                    int i = 0;
                    foreach (Acc b in cust.AccList)
                    {
                        ++i;
                        Console.WriteLine($"SelectID:{i} --CustomerId: {b.id} - Firstname: {cust.Firstname} - Lastname: {cust.Lastname} -Account Number: {b.Accountnum}- Amount: {b.Amount}");
                    }
                }
            }
            return cust.AccList;
        }
        public void getallloan(int id)
        {
            Customer cust = DAL.GetCustomer(id);
            if (id == cust.Id)
            {
                foreach (Loan b in cust.loanList)
                {
                    Console.WriteLine($"Id: {cust.Id} - Firstname: {cust.Firstname} - Lastname: {cust.Lastname} -Account Number: {b.id}");
                }
            }

        }
        public Customer Get(int id)
        {

            try
            {
                var customer = DAL.GetCustomer(id);
                if (customer != null)
                {
                    // Data found. Process it and return to UI.
                    return customer;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Log it.
                throw;
            }
        }
        public Acc GetAcc(int id)
        {

            try
            {
                var acc = DAL.GetAccount(id);
                if (acc != null)
                {
                    // Data found. Process it and return to UI.
                    return acc;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Log it.
                throw;
            }
        }
        public List<Customer> GetAll()
        {
            CustomerDAL dal = new CustomerDAL();
            var customers = dal.GetAll();

            return customers;
        }

    }
}