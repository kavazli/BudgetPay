using System;
using BudgetPay.Domain;

namespace BudgetPay.Application.Interfaces;

public interface IEmployeeCalculator
{
    List<MonthlyPayroll> CalculateAnnualPayroll(Employee employee);
    MonthlyPayroll CalculateMonthlyPayroll(Employee employee, EmployeeCumulativeTaxState state, int month);

}
