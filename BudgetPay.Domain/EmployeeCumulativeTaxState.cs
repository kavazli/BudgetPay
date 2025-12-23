
namespace BudgetPay.Domain;


// Yıllık gelir vergisi matrahını tutmak için kullanılan entity
public class EmployeeCumulativeTaxState
{
    public decimal CumulativeIncomeTaxBase { get; set; }
    

    public void AddMonthlyIncomeTaxBase(decimal IncomeTaxBase)
    {
        if (IncomeTaxBase < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(IncomeTaxBase), "Income tax base cannot be negative");
        }
        CumulativeIncomeTaxBase += IncomeTaxBase;
    }
}
