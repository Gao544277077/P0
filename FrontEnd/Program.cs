using BusinessLayer;
using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("1:Register\n2:Open new account\n3:Close the account\n4:Login\n5.List of account\n6.List of loan");
                    int sele = Convert.ToInt32(Console.ReadLine());
                    switch (sele)
                    {
                        case 1:
                            register();
                            break;
                        case 2:
                            open();
                            break;
                        case 3:
                            close();
                            break;
                     
                        case 4:
                            login();
                            break;
                        case 5:
                            list();
                            break;
                        case 6:
                            listofloan();
                            break;
                        default:
                            Console.WriteLine("not this choice");
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.StackTrace);
            }
        }

        public static void register()
        {
            CustomerBL O = new CustomerBL();
            O.Create();
            foreach (var person in O.GetAll())
            {
                try
                {
                    if (person != null)
                    {
                        Console.WriteLine($"Id: {person.Id} - Firstname: {person.Firstname} - Lastname: {person.Lastname}");
                    }

                    else
                    {
                        Console.WriteLine("Record not found...");
                    }
                }
                catch (Exception ex)
                {
                    // Log it.
                    Console.WriteLine("ERROR: " + ex.Message);
                }
            }
        }
        public static void open()
        {
            try
            {
                CustomerBL bl = new CustomerBL();
                Console.WriteLine("Enter your Id");
                int i = Convert.ToInt32(Console.ReadLine());
                bl.openAcc(i);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static void close()
        {
            CustomerBL bl = new CustomerBL();
            Console.WriteLine("Enter your Id");
            int i = Convert.ToInt32(Console.ReadLine());
            bl.closeAcc(i);
        }
        public static void login()
        {

            CustomerBL bl = new CustomerBL();
            try
            {
                Console.WriteLine("Enter your Id");
                int id = Convert.ToInt32(Console.ReadLine());
                Customer a = bl.Get(id);
                //foreach (Customer a in CustomerDAL.customerList)
                //{
                if (a.Id == id)
                {
                    Console.WriteLine("(1)Manage your Account\n(2)Loan");
                    int c = Convert.ToInt32(Console.ReadLine());
                    if (c == 2)
                    {
                        Console.WriteLine("(1)Apply to a loan plan\n(2)Pay loan");
                        c = Convert.ToInt32(Console.ReadLine());
                        if (c == 1)
                        {
                            bl.Applyloan(id);
                        }
                        else if (c == 2)
                        {
                            bl.payloan(id);
                        }

                    }
                    else if (c == 1)
                    {
                        Console.WriteLine("There is list of your account.");
                        bl.getallacc(a.Id);


                        //Console.WriteLine("choose a Account");
                        //string accountnum = Console.ReadLine();
                        //foreach (Acc b in a.AccList)
                        //{

                        //try
                        //{
                        //if (accountnum == b.Accountnum)
                        Acc b = bl.GetAcc(id);
                        {
                            Console.WriteLine(" 1.Deposit \n 2.Withdrawls \n 3.Transifer \n 4.Checking Transation");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            if (choice == 1)
                            {
                                Console.WriteLine("Enter the Amount:");
                                double n = Convert.ToDouble(Console.ReadLine());
                                n = Convert.ToDouble(n.ToString("#.##"));
                                b.deposit(n);
                            }
                            else if (choice == 2)
                            {
                                Console.WriteLine("Enter the Amount:");
                                double n = Convert.ToDouble(Console.ReadLine());
                                n = Convert.ToDouble(n.ToString("#.##"));
                                b.withdrawls(n);
                                Console.WriteLine(b.Amount);
                            }
                            else if (choice == 3)
                            {
                                Console.WriteLine("Enter the account number to transfer");
                                string num = Console.ReadLine();
                                Console.WriteLine("Enter the amount that transfer to the " + num);

                                double n = Convert.ToDouble(Console.ReadLine());
                                n = Convert.ToDouble(n.ToString("#.##"));
                                bool tran = bl.trsansfer(a, n, num);
                                if (tran == true) {
                                    b.withdrawls(n);
                                    Console.WriteLine(b.Amount);
                                }
                            }
                            else if (choice == 4)
                            {
                                b.TransactionHistory();
                            }


                            else
                            {
                                Console.Write("Not this selection, System will automatic return to menu");
                            }

                        }
                    }
                    //catch (Exception)
                    //{
                    //    Console.WriteLine("something error, try again");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message + " try agagin");
            }
        }
        public static void list(){
            CustomerBL bl = new CustomerBL();
            Console.WriteLine("Enter your Id");
            int i = Convert.ToInt32(Console.ReadLine());
            bl.getallacc(i);

        }
        public static void listofloan()
        {
            CustomerBL bl = new CustomerBL();
            Console.WriteLine("Enter your Id");
            int i = Convert.ToInt32(Console.ReadLine());
            bl.getallloan(i);

        }


    }
}
