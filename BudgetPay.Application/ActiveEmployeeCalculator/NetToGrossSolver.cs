using System;
using BudgetPay.Domain;

namespace BudgetPay.Application;

public static class NetToGrossSolver
{
    public static MonthlyPayroll NetToGrossIteration(Employee employee, EmployeeCumulativeTaxState state, int month)
    {   
        Employee empCopy = new Employee
        {
            FullName = employee.FullName,
            NationalIdNumber = employee.NationalIdNumber,
            Department = employee.Department,
            CostCenter = employee.CostCenter,
            PayType = employee.PayType,
            Status = employee.Status,
            BaseSalary = employee.BaseSalary,
            SalaryIncreaseRate = employee.SalaryIncreaseRate,
            PlannedMonthlyOvertimeHours = employee.PlannedMonthlyOvertimeHours,
            PlannedBonusAmount = employee.PlannedBonusAmount,
            BonusFrequency = employee.BonusFrequency,
            PlannedVoucherAmount = employee.PlannedVoucherAmount,
            VoucherFrequency = employee.VoucherFrequency
        };

        decimal netUcret =empCopy.BaseSalary;
        decimal fark = 0m;
        decimal tolerans = 0.00001m;
        GrossToNetPayrollCalculator calculator = new GrossToNetPayrollCalculator();
        MonthlyPayroll pay = new MonthlyPayroll();

        for(int i=0; i < 200; i++)
        {

            pay = calculator.CalculateMonthlyPayrollFromGross(empCopy, state, month);
            fark = netUcret - pay.NetSalary;
            if(fark < tolerans)
            {
                break;
            }
            
            if(fark > tolerans)
            {
                empCopy.BaseSalary = pay.GrossSalary + fark;
            }
        }
        return pay;
    }
}