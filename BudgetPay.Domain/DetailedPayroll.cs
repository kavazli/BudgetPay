using System;

namespace BudgetPay.Domain;

public class DetailedPayroll
{
    
    private readonly Dictionary<string, List<MonthlyPayroll>> _payrolls
        = new Dictionary<string, List<MonthlyPayroll>>();

    
    public IReadOnlyDictionary<string, List<MonthlyPayroll>> Payrolls => _payrolls;

    
    public void AddPayroll(Employee employee, MonthlyPayroll monthlyPayroll)
    {
        if (employee == null)
        {
            throw new ArgumentNullException(nameof(employee), "Employee cannot be null");
        }
        if (monthlyPayroll == null)
        {
            throw new ArgumentNullException(nameof(monthlyPayroll), "MonthlyPayroll cannot be null");
        }
        
        string key = employee.NationalIdNumber;

        
        if (!_payrolls.TryGetValue(key, out var list))
        {
            list = new List<MonthlyPayroll>();
            _payrolls[key] = list;
        }

        
        list.Add(monthlyPayroll);
    }
}
