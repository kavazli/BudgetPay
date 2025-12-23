
namespace BudgetPay.Domain;


// Hesaplanan yıllık bordro verilerini tutmak için kullanılan entity
public class EmployeeAnnualPayroll
{
    
    public List<MonthlyPayroll> AnnualPayrolls { get; }

    public EmployeeAnnualPayroll()
    {
        AnnualPayrolls = new();
    }

    // Aylık bordro ekleme metodu
    public void Add(MonthlyPayroll monthlyPayroll)
    {   
        if (monthlyPayroll == null)
        {
            throw new ArgumentNullException(nameof(monthlyPayroll));
        }

        AnnualPayrolls.Add(monthlyPayroll);
    }
}
