using System;
using Entities;
namespace BusinessLayer
{
    public class loanBL
    {
        public Loan plan1(double loans)
        {

            Loan l = new Loan();
            l.interest = 0.1;
            //12 month
            l.period = 12;
            l.remaindertime = 30;
            l.Expiredate = DateTime.Now.AddMonths(1);
            l.loan = loans * l.interest + loans;
            l.loan=Convert.ToDouble(l.loan.ToString("#.##"));
            l.monthlypay = l.loan / l.period;
            l.monthlypay = Convert.ToDouble(l.monthlypay.ToString("#.##"));
            if (l.remaindertime == 0 && l.pay == false)
            {
                //increase 25% of monthlypay;
                l.loan += (l.monthlypay / 4);
                l.monthlypay = l.loan / l.period;
                l.monthlypay = Convert.ToDouble(l.monthlypay.ToString("#.##"));
                l.Expiredate.AddMonths(1);
            }
            return l;
        }
        public Loan plan2(double loans)
        {
            Loan l = new Loan();
            l.interest = 0.15;
            //12 month
            l.period = 60;
            l.remaindertime = 30;
            l.Expiredate = DateTime.Now.AddMonths(1);
            l.loan = Convert.ToDouble(l.loan.ToString("#.##"));
            l.monthlypay = l.loan / l.period;
            l.monthlypay = Convert.ToDouble(l.monthlypay.ToString("#.##"));
            if (l.Expiredate == DateTime.Now && l.pay == false)
            {
                //increase 25% of monthlypay;
                l.loan += (l.monthlypay / 4);
                l.monthlypay = l.loan / l.period;
                l.monthlypay = Convert.ToDouble(l.monthlypay.ToString("#.##"));
                l.Expiredate.AddMonths(1);
            }
            return l;
        }
    }
}

