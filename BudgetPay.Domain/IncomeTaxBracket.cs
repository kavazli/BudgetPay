
namespace BudgetPay.Domain;


// Yıllık gelir vergisi dilimini temsil eden sınıf
public class IncomeTaxBracket
{
    public decimal MinAmount { get; }
    public decimal MaxAmount { get; }
    public decimal Rate { get; }
    public decimal More { get; }

    
    // Yapıcı metot, gelir vergisi dilimi parametrelerini alır ve doğrular
    public IncomeTaxBracket(decimal minAmount, decimal maxAmount, decimal rate, decimal more)
    {
        if (minAmount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(minAmount), "MinAmount cannot be negative.");
        }
        if (maxAmount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxAmount), "MaxAmount cannot be negative.");
        }
        if (maxAmount < minAmount)
        {
            throw new ArgumentException("MaxAmount must be greater than or equal to MinAmount.");
        }
        if (rate < 0 || rate > 1)
        {
            throw new ArgumentOutOfRangeException(nameof(rate), "Rate must be between 0 and 1.");
        }
        if (more < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(more), "More cannot be negative.");
        }

        MinAmount = minAmount;
        MaxAmount = maxAmount;
        Rate = rate;
        More = more;
    }
   

}
