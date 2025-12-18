
using System;
using System.ComponentModel.DataAnnotations;
using BudgetPay.Domain;

namespace BudgetPay.Application;

public class PayrollCalculator
{   
    
    

    public MonthlyPayroll CalculateMonthlyFromGross(Employee employee, EmployeeCumulativeTaxState state, int month)
{

        if (employee == null)
        {
            throw new NullReferenceException(nameof(employee));
        }
        if (state == null)
        {
             throw new NullReferenceException(nameof(employee));
        }
        if (month < 1 || month > 12)
        {
            throw new IndexOutOfRangeException(nameof(month));
        }

        

        MonthlyPayroll pay = new MonthlyPayroll();

        pay.Employee = employee;
        pay.Year = 0;
        pay.Month = month;
        pay.NetSalary = employee.BaseSalary;
        decimal TempPay = employee.BaseSalary;
   
        pay.EmployeeSSContributionAmount = SocialSecurityCalculator.EmployeeSocialSecurityResult(TempPay);
        pay.EmployeeUnemploymentInsuranceContributionAmount = SocialSecurityCalculator.EmployeeUnemploymentInsuranceResult(TempPay);
        pay.IncomeTaxBase = TempPay - (pay.EmployeeSSContributionAmount + pay.EmployeeUnemploymentInsuranceContributionAmount);
        pay.CumulativeIncomeTaxBase = state.CumulativeIncomeTaxBase + pay.IncomeTaxBase;
        pay.IncomeTax = IncomeTaxCalculator.CalculateTax(pay.IncomeTaxBase, state);
        pay.StampTax = StampTaxCalculator.CalculeteStampTax(TempPay);

        pay.GrossSalary = pay.NetSalary + pay.EmployeeSSContributionAmount + pay.EmployeeUnemploymentInsuranceContributionAmount + pay.IncomeTax + pay.StampTax;
        pay.EmployerSSContributionAmount = 0m;
        pay.EmployerUnemploymentInsuranceContributionAmount = 0m;
        pay.IncentiveDiscount = 0m;
        pay.TotalEmployerCost = pay.GrossSalary;

    
        return pay;
}






}
