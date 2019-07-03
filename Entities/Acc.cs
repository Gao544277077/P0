using System;
using System.Collections.Generic;

namespace Entities
{
    public abstract class Acc
    {
        public int id;
        public double Amount;
        public string Accountnum;
        //10%
        public const double interest = 10;
        public double loan;
        public List<string> Transaction = new List<string>();
        public void deposit(double n)
        {
            Console.WriteLine("Enter the amount:");
            this.Amount += n;
            Console.WriteLine("Your have depoist:" + n + "   And your total is:" + this.Amount);
            Transaction.Add("Deposit:   +" + n);
        }
        public abstract void withdrawls(double n);
        public void TransactionHistory()
        {
            foreach (string s in Transaction)
            {
                Console.WriteLine(s);
            }


        }
    }
}
