using System;

namespace BudgetPay.Application;

public static class IncomeTaxExemption
{
    public static decimal IncomeExemption(int month)
    {

        if (month < 1 || month > 12)
        {
            throw new IndexOutOfRangeException(nameof(month));
        }

        decimal taxBaseExemption = StatutoryParameters.MinimumWage.NetAmount * month;

        decimal bracket1 = StatutoryParameters.IncomeTaxBrackets.Brackets[0].MaxAmount;
        decimal bracket1Rate = StatutoryParameters.IncomeTaxBrackets.Brackets[0].Rate;

        decimal bracket2 = StatutoryParameters.IncomeTaxBrackets.Brackets[1].MaxAmount;
        decimal bracket2Rate = StatutoryParameters.IncomeTaxBrackets.Brackets[1].Rate;

        decimal netAmount = StatutoryParameters.MinimumWage.NetAmount;
        decimal result = 0;

        if (taxBaseExemption < bracket1)
        {
            return result = netAmount * bracket1Rate;
        }
        else if (taxBaseExemption > bracket1 && (taxBaseExemption - bracket1) < netAmount)              
        {
            return result = ((taxBaseExemption - bracket1) * bracket2Rate) + ((netAmount - (taxBaseExemption - bracket1)) * bracket1Rate);
                     
        }
        else if (taxBaseExemption > bracket1 && (taxBaseExemption - bracket1) > netAmount)
                
        {
            return result = netAmount * bracket2Rate;
        }
        else
        {
            return result;
        }

        
    }
}
