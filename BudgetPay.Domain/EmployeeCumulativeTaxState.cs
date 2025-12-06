using System;

namespace BudgetPay.Domain;

public class EmployeeCumulativeTaxState
{
    public Employee Employee { get; }
    public decimal CumulativeIncomeTaxBase { get; private set; }
    public int Year { get; }

    public EmployeeCumulativeTaxState(Employee employee, decimal cumulativeIncomeTaxBase, int year)
    {   
        
        if(employee == null)
        {
            throw new ArgumentNullException(nameof(employee), "Employee cannot be null");
        }
        if(year <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(year), "Year must be positive");
        }
        if(cumulativeIncomeTaxBase < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(cumulativeIncomeTaxBase), "CumulativeIncomeTaxBase cannot be negative");
        }
        Employee = employee;
        CumulativeIncomeTaxBase = cumulativeIncomeTaxBase;
        Year = year;
    }

    public void AddMonthlyIncomeTaxBase(decimal monthlyBase)
    {
        if (monthlyBase < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(monthlyBase), "Monthly base cannot be negative");
        }
        CumulativeIncomeTaxBase += monthlyBase;
    }
}
