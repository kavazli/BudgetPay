using System;

namespace BudgetPay.Domain;

public class EmployeeAnnualPayroll
{
    public Employee Employee { get; }
    public List<MonthlyPayroll> AnnualPayrolls { get; }

    public EmployeeAnnualPayroll(Employee employee, List<MonthlyPayroll> annualPayrolls)
    {   

        if( employee == null || annualPayrolls.Count != 12 || annualPayrolls == null )
        {
            throw new ArgumentException("Annual payrolls must contain exactly 12 monthly payrolls.");
        }
        this.Employee = employee;
        this.AnnualPayrolls = annualPayrolls;
    }
}
