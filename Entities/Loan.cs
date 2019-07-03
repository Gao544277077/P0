using System;
namespace Entities
{
    public class Loan
    {
        public int id;
        public double loan;
        public int period;
        public double interest;
        public double monthlypay;
        public int remaindertime;
        public DateTime Expiredate;
        public bool pay = false;
        public Loan()
            
        {
        }
    }
}