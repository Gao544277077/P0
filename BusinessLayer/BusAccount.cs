using System;
using Entities;

namespace BusinessLayer
{
    public class BusAcc : Acc
    {


        public override void withdrawls(double n)
        {

            Console.WriteLine("Enter the amount:");
            this.Amount -= n;
            if (Amount < 0)
            {
                double remainder = 0;
                remainder = 0 - this.Amount;
                remainder = remainder * Acc.interest / 100;
                Amount = this.Amount - remainder;
                Amount = Convert.ToDouble(Amount.ToString("#.##"));
            }
            Console.WriteLine("Your have withdrawls:" + n + "   And your total is:" + this.Amount);
            Transaction.Add("withdrawls:   -" + n);
        }
    }
}

