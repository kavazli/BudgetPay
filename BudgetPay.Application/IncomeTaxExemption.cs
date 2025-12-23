
namespace BudgetPay.Application;


// Gelir vergisi muafiyeti hesaplayan sınıf
public static class IncomeTaxExemption
{   
    // Gelir vergisi muafiyetini hesaplayan metot
    public static decimal IncomeExemption(int month)
    {

        if (month < 1 || month > 12 || month == 0)
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

        // Eğer vergi matrahı muafiyeti asgari ücretin birinci vergi diliminden az ise birinci dilim oranı ile çarpılır
        if (taxBaseExemption < bracket1)
        {
            return result = netAmount * bracket1Rate;
        }
        else if (taxBaseExemption > bracket1 && (taxBaseExemption - bracket1) < netAmount)              
        {   // Eğer vergi matrahı muafiyeti asgari ücretin birinci vergi diliminden büyük ve ikinci vergi diliminden az ise
            return result = ((taxBaseExemption - bracket1) * bracket2Rate) + ((netAmount - (taxBaseExemption - bracket1)) * bracket1Rate);
                     
        }
        else if (taxBaseExemption > bracket1 && (taxBaseExemption - bracket1) > netAmount)
                
        {   // Eğer vergi matrahı muafiyeti asgari ücretin ikinci vergi diliminden büyük ise ikinci dilim oranı ile çarpılır
            return result = netAmount * bracket2Rate;
        }
        else
        {
            return result;
        }

        
    }
}
