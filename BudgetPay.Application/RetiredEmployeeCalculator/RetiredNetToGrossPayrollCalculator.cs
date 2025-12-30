using System;
using BudgetPay.Application.Interfaces;
using BudgetPay.Domain;

namespace BudgetPay.Application.RetiredEmployeeCalculator;

public class RetiredNetToGrossPayrollCalculator : IEmployeeCalculator
{

    // Yıllık bordroyu Net maaştan hesaplayan metot
    public List<MonthlyPayroll> CalculateAnnualPayroll(Employee employee)
    {
        if (employee == null)
        {
            throw new ArgumentNullException(nameof(employee));
        }

        EmployeeAnnualPayroll Grosslist = new();
        MonthlyPayroll pay;
        EmployeeCumulativeTaxState state = new();
        for (int i = 1; i <= 12; i++)
        {

            pay = RetiredNetToGrossSolver.NetToGrossIteration(employee, state, i);
            state.AddMonthlyIncomeTaxBase(pay.IncomeTaxBase);
            Grosslist.Add(pay);
        }
        return Grosslist.AnnualPayrolls;
    }


    // Aylık bordroyu Brüt maaştan hesaplayan metot ( sınıf net hesaplayıcı olmasına rağmen bu metot brüt hesaplama yapıyor çünkü netten brüte iterasyon için gerekli)
    public MonthlyPayroll CalculateMonthlyPayroll(Employee employee, EmployeeCumulativeTaxState state, int month)
    {

        if (employee == null)
        {
            throw new ArgumentNullException(nameof(employee));
        }
        if (state == null)
        {
            throw new ArgumentNullException(nameof(state));
        }
        if (month < 1 || month > 12)
        {
            throw new ArgumentOutOfRangeException(nameof(month));
        }



        MonthlyPayroll pay = new MonthlyPayroll();

        pay.Fullname = employee.FullName;
        pay.NationalIdNumber = employee.NationalIdNumber;
        pay.Department = employee.Department;
        pay.CostCenter = employee.CostCenter;

        pay.Year = 0;
        pay.Month = month;
        
        
        pay.GrossSalary = employee.BaseSalary;

        // Social Security Contributions
        pay.EmployeeSSContributionAmount = SocialSecurityCalculator.RetiredEmployeeSocialSecurityResult(pay.GrossSalary);
        pay.EmployeeUnemploymentInsuranceContributionAmount = 0m;
        
        // Income Tax and Stamp Tax
        pay.IncomeTaxBase = pay.GrossSalary - (pay.EmployeeSSContributionAmount + pay.EmployeeUnemploymentInsuranceContributionAmount);
        pay.CumulativeIncomeTaxBase = state.CumulativeIncomeTaxBase + pay.IncomeTaxBase;
        pay.IncomeTax = IncomeTaxCalculator.CalculateTax(pay.IncomeTaxBase, state) - IncomeTaxExemption.IncomeExemption(month);
        pay.IncomeTaxExemption = IncomeTaxExemption.IncomeExemption(month);
        pay.StampExemption = StampTaxExemption.StampExemption();
        pay.StampTax = StampTaxCalculator.CalculeteStampTax(pay.GrossSalary) - StampTaxExemption.StampExemption();


        pay.NetSalary = pay.GrossSalary - (pay.EmployeeSSContributionAmount + pay.EmployeeUnemploymentInsuranceContributionAmount + pay.IncomeTax + pay.StampTax);
        

        // Employer Contributions
        pay.EmployerSSContributionAmount = SocialSecurityCalculator.RetiredEmployerSocialSecurityResult(pay.GrossSalary);   
        pay.EmployerUnemploymentInsuranceContributionAmount = 0m;
        pay.IncentiveDiscount = 0m;
        pay.TotalEmployerCost = pay.GrossSalary + pay.EmployerSSContributionAmount + pay.EmployerUnemploymentInsuranceContributionAmount;

        return pay;
    }
    
}
