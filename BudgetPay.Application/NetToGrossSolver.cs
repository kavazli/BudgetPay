using System;
using BudgetPay.Domain;

namespace BudgetPay.Application;

public static class NetToGrossSolver
{
    public static MonthlyPayroll NetToGrossIteration(Employee employee)
    {   
        decimal NetSalary = employee.BaseSalary;
        
        Employee Tempemployee= employee;
        
        PayrollCalculator PayrollCalculator = new PayrollCalculator();
       
        MonthlyPayroll Iteration = new MonthlyPayroll();

        while (NetSalary != Iteration.NetSalary)
        {
            Iteration = PayrollCalculator.CalculateMonthlyPayrollFromGross(Tempemployee, new EmployeeCumulativeTaxState(), 1);
            Tempemployee.BaseSalary =Iteration.GrossSalary;
            
            
        }
        
        return Iteration;
    }
}
