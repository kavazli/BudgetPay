
namespace BudgetPay.Domain;


// Asgari ücretin netini ve brütünü temsil eden sınıf
public class MinimumWage
{
    public decimal GrossAmount { get; }
    public decimal NetAmount { get; }

    public MinimumWage(decimal grossAmount, decimal netAmount)
    {   

        if( grossAmount <= 0 )
        {
            throw new ArgumentOutOfRangeException(nameof(grossAmount), "Gross amount cannot be negative.");
        }
        if( netAmount <= 0 )
        {
            throw new ArgumentOutOfRangeException(nameof(netAmount), "Net amount cannot be negative.");
        }
        if( netAmount > grossAmount )
        {
            throw new ArgumentException("Net amount cannot be greater than gross amount.");
        }
   
        GrossAmount = grossAmount;
        NetAmount = netAmount;
    }

}
