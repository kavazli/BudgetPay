
namespace BudgetPay.Application;


// Damga vergisi muafiyeti hesaplayan sınıf
public static class StampTaxExemption
{
    public static decimal StampExemption()
    {
        decimal result = StatutoryParameters.MinimumWage.GrossAmount * StatutoryParameters.StampTax.Rate;
        return result;
    }
}
