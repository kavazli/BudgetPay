
namespace BudgetPay.Application;


// Damga vergisi muafiyeti hesaplayan sınıf
public static class StampTaxExemption
{
    public static decimal StampExemption()
    {   

        if (StatutoryParameters.MinimumWage == null || StatutoryParameters.StampTax == null)
        {
            throw new InvalidOperationException("Statutory parameters are not initialized.");
        }   
        decimal result = StatutoryParameters.MinimumWage!.GrossAmount * StatutoryParameters.StampTax!.Rate;
        return result;
    }
}
