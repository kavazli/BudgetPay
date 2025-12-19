
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
        pay.GrossSalary = employee.BaseSalary;

        // Social Security Contributions
        pay.EmployeeSSContributionAmount = SocialSecurityCalculator.EmployeeSocialSecurityResult(pay.GrossSalary);
        pay.EmployeeUnemploymentInsuranceContributionAmount = SocialSecurityCalculator.EmployeeUnemploymentInsuranceResult(pay.GrossSalary);
        // Income Tax and Stamp Tax
        pay.IncomeTaxBase = pay.GrossSalary - (pay.EmployeeSSContributionAmount + pay.EmployeeUnemploymentInsuranceContributionAmount);
        pay.CumulativeIncomeTaxBase = state.CumulativeIncomeTaxBase + pay.IncomeTaxBase;
        pay.IncomeTax = IncomeTaxCalculator.CalculateTax(pay.IncomeTaxBase, state) - IncomeTaxExemption.IncomeExemption(month);
        pay.IncomeTaxExemption = IncomeTaxExemption.IncomeExemption(month);
        pay.StampExemption = StampTaxExemption.StampExemption();
        pay.StampTax = StampTaxCalculator.CalculeteStampTax(pay.GrossSalary) - StampTaxExemption.StampExemption();

       
        pay.NetSalary = pay.GrossSalary - (pay.EmployeeSSContributionAmount + pay.EmployeeUnemploymentInsuranceContributionAmount + pay.IncomeTax + pay.StampTax);
        pay.TotalEmployerCost = pay.GrossSalary;

        // Employer Contributions
        pay.EmployerSSContributionAmount = 0m;
        pay.EmployerUnemploymentInsuranceContributionAmount = 0m;
        pay.IncentiveDiscount = 0m;
        

    
        return pay;
    }

}
