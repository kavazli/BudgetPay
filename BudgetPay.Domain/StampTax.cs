
namespace BudgetPay.Domain;


// Damga vergisini temsil eden sınıf
public class StampTax
{
    public decimal Rate { get; }

    public StampTax(decimal rate)
    {
        if(rate <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(rate),"Stamp tax amount must be greater than 0.");
        }

        this.Rate = rate;
    }
}
