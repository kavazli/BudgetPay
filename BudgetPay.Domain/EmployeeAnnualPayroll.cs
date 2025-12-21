using System;

namespace BudgetPay.Domain;

public class EmployeeAnnualPayroll
{
    
    public List<MonthlyPayroll> AnnualPayrolls { get; }

    public EmployeeAnnualPayroll()
    {
        AnnualPayrolls = new();
    }

    public void Add(MonthlyPayroll monthlyPayroll)
    {   
        if (monthlyPayroll == null)
        {
            throw new ArgumentNullException(nameof(monthlyPayroll));
        }

        AnnualPayrolls.Add(monthlyPayroll);
    }
}
