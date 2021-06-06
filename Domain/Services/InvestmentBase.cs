using System;

namespace Domain.Services
{
    public abstract class InvestmentBase
    {
        public virtual double GetRedemptionTax(DateTime endTime, DateTime startTime, DateTime dtConsult)
        {
            double tax = 0;

            int contractDays = (endTime - startTime).Days;
            int currentDays = (endTime - dtConsult).Days;

            if (currentDays > 0)
            {
                if (contractDays / currentDays < 2) tax = 0.15;
                else if (contractDays - currentDays <= 90) tax = 0.06;
                else tax = 0.30;
            }

            return tax;
        }
    }
}
