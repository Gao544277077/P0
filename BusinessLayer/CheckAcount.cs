using System;
using Entities;

namespace BusinessLayer
{
    public class CheckAcc : Acc
    {
        public override void withdrawls(double n)
        {
            if (Amount >= n)
            {
                Console.WriteLine("Enter the amount:");
                this.Amount -= n;
                Transaction.Add("withdrawls:   -" + n);
                Console.WriteLine("Your have depoist:" + n + "  And your total is:" + this.Amount);
            }
            else
            {
                Console.WriteLine("Your can not pay this payment with this account");
            }
        }
    }
}
