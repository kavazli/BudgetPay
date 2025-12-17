using System;

namespace BudgetPay.Domain;

public class TempPay
{
    public int Month { get; set; }
    public decimal NetSalary { get; set; }
    public decimal TempNetSalary { get; set; }
    public decimal EmployeeSSContributionAmount { get; set; }
    public decimal EmployeeUnemploymentInsuranceContributionAmount { get; set; }
    public decimal CumulativeIncomeTaxBase { get; set; }
    public decimal IncomeTaxBase { get; set; }
    public decimal IncomeTax { get; set; }
    public decimal IncomeTaxExemption { get; set; }
    public decimal StampTax { get; set; }
    public decimal GrossSalary { get; set; }
}
