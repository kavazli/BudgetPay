

using BudgetPay.Domain;


namespace BudgetPay.Application;

// Aylık bordro hesaplayıcı sınıfı
public class PayrollCalculator
{   

    // Yıllık bordroyu brüt maaştan hesaplayan metot
    public List<MonthlyPayroll> CalculateAnnualPayrollFromGross(Employee employee)
    {
        if (employee == null)
        {
            throw new NullReferenceException(nameof(employee));
        }

        EmployeeAnnualPayroll list = new();
        MonthlyPayroll pay = new();
        EmployeeCumulativeTaxState state = new();
        for (int i = 1; i <= 12; i++)
        {

            pay = CalculateMonthlyPayrollFromGross(employee, state, i);
            state.AddMonthlyIncomeTaxBase(pay.IncomeTaxBase);
            list.Add(pay);
        }
        return list.AnnualPayrolls;
    }
    
    // Aylık bordroyu brüt maaştan hesaplayan metot
    private MonthlyPayroll CalculateMonthlyPayrollFromGross(Employee employee, EmployeeCumulativeTaxState state, int month)
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

        pay.Fullname = employee.FullName;
        pay.NationalIdNumber = employee.NationalIdNumber;
        pay.Department = employee.Department;
        pay.CostCenter = employee.CostCenter;

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
        

        // Employer Contributions
        pay.EmployerSSContributionAmount = SocialSecurityCalculator.EmployerSocialSecurityResult(pay.GrossSalary);   
        pay.EmployerUnemploymentInsuranceContributionAmount = SocialSecurityCalculator.EmployerUnemploymentInsuranceResult(pay.GrossSalary);
        pay.IncentiveDiscount = 0m;
        pay.TotalEmployerCost = pay.GrossSalary + pay.EmployerSSContributionAmount + pay.EmployerUnemploymentInsuranceContributionAmount;

        return pay;
    }

}
