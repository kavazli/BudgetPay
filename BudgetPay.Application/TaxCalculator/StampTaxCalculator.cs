
namespace BudgetPay.Application;


// Damga vergisi hesaplayıcı sınıfı
public static class StampTaxCalculator
{   
    
    public static decimal CalculeteStampTax(decimal grossSalary)
    {   
        if(grossSalary < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(grossSalary), "Gross salary must be greater than 0.");
        }

        return grossSalary * StatutoryParameters.StampTax.Rate;
    }
}
