using System;

namespace BudgetPay.Domain;

public class MonthlyPayroll
{   
    public string Fullname { get; set; } = string.Empty;
    public string NationalIdNumber { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string CostCenter { get; set; } = string.Empty;


    public int Month { get; set; }
    public int Year { get; set; }

    public decimal NetSalary { get; set; }
    public decimal GrossSalary { get; set; }

    public decimal EmployeeSSContributionAmount { get; set; }
    public decimal EmployeeUnemploymentInsuranceContributionAmount { get; set; }

    public decimal CumulativeIncomeTaxBase { get;set; }
    public decimal IncomeTaxBase { get;set; }

    public decimal IncomeTax { get;set; }
    public decimal IncomeTaxExemption { get;set; }

    public decimal StampTax { get;set; }
    public decimal StampExemption { get; set; }

    public decimal EmployerSSContributionAmount { get; set; }
    public decimal EmployerUnemploymentInsuranceContributionAmount { get;set; }

    public decimal IncentiveDiscount { get; set;}

    public decimal TotalEmployerCost { get;set; }

}
