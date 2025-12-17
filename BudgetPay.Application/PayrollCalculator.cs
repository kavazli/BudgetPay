using System;
using System.ComponentModel.DataAnnotations;
using BudgetPay.Domain;

namespace BudgetPay.Application;

public class PayrollCalculator
{   
    
    private readonly NetToGrossSolver _solver = null!;
    

    public TempPay CalculateMonthlyFromGross(decimal payroll, EmployeeCumulativeTaxState state, int month)
{
    
    if (state == null)
    {
        throw new ArgumentException("Cumulative tax state must be initialized.");
    }
    if (month < 1 || month > 12)
    {
        throw new ArgumentException("Month must be between 1 and 12.");
    }
    if (payroll < 0)
    {
        throw new ArgumentException("Payroll must be non-negative.");
    }

    var pay = new TempPay();
    pay.Month = month;
    
    pay.GrossSalary = payroll;

    pay.EmployeeSSContributionAmount =
        SocialSecurityCalculator.EmployeeSocialSecurityResult(pay.GrossSalary, SocialSecurityParameters.Default);

    pay.EmployeeUnemploymentInsuranceContributionAmount =
        SocialSecurityCalculator.EmployeeUnemploymentInsuranceResult(pay.GrossSalary, SocialSecurityParameters.Default);

    pay.IncomeTaxBase = pay.GrossSalary
        - (pay.EmployeeSSContributionAmount + pay.EmployeeUnemploymentInsuranceContributionAmount);

    state.AddMonthlyIncomeTaxBase(pay.IncomeTaxBase);

    pay.IncomeTax = IncomeTaxCalculator.CalculateTax(pay.IncomeTaxBase, IncomeTaxBrackets.Default, state);

    pay.StampTax = StampTaxCalculator.CalculeteStampTax(pay.GrossSalary, StampTaxCalculator.DefaultStampTax);

    // Net = Brüt - kesintiler
            

    pay.NetSalary = pay.GrossSalary - (pay.EmployeeSSContributionAmount + pay.EmployeeUnemploymentInsuranceContributionAmount );    

    return pay;
}






}
