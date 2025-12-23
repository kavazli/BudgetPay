
using BudgetPay.Domain;


// Yasal Pametreleri ve hesaplama için gerekli sabit değerleri tutan sınıf, her alanda kullanabilmek için statik olarak tanımlanmıştır
namespace BudgetPay.Application;

public static class StatutoryParameters
{
    public static SocialSecurityParameters? SocialSecurityParameters { get; private set; }
    public static IncomeTaxBrackets? IncomeTaxBrackets { get; private set; }

    public static StampTax? StampTax { get; private set; }
    public static MinimumWage? MinimumWage { get; private set; }

    public static void Initialize(SocialSecurityParameters socialSecurityParameters,
                                    IncomeTaxBrackets İncomeTaxBrackets,
                                    StampTax stampTax,
                                    MinimumWage minimumWage)
    {

        if (socialSecurityParameters == null)
        {
            throw new NullReferenceException(nameof(socialSecurityParameters));
        }
        if (İncomeTaxBrackets == null)
        {
            throw new NullReferenceException(nameof(İncomeTaxBrackets));
        }
        if (stampTax == null)
        {
            throw new NullReferenceException(nameof(stampTax));
        }
        if (minimumWage == null)
        {
            throw new NullReferenceException(nameof(minimumWage));
        }

        SocialSecurityParameters = socialSecurityParameters;
        IncomeTaxBrackets = İncomeTaxBrackets;
        StampTax = stampTax;
        MinimumWage = minimumWage;
    }

    
}
