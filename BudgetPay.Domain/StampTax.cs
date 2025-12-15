using System;

namespace BudgetPay.Domain;

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
