using System;

namespace BudgetPay.Domain;

public class MonthlyPayroll
{
    public Employee Employee { get; set; }
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

    

    // public MonthlyPayroll(
    //     Employee employee,
    //     int month,
    //     int year,
    //     decimal netSalary,
    //     decimal grossSalary,
    //     decimal employeeSSContributionAmount,
    //     decimal employeeUnemploymentInsuranceContributionAmount,
    //     decimal cumulativeIncomeTaxBase,
    //     decimal incomeTaxBase,
    //     decimal incomeTax,
    //     decimal incomeTaxExemption,
    //     decimal stampTax,
    //     decimal employerSSContributionAmount,
    //     decimal employerUnemploymentInsuranceContributionAmount,
    //     decimal incentiveDiscount,
    //     decimal totalEmployerCost)
    // {

    //     if (employee == null)
    //         throw new ArgumentNullException(nameof(employee));

    //     if (month < 1 || month > 12)
    //         throw new ArgumentOutOfRangeException(nameof(month), "Month must be between 1 and 12.");

    //     if (year <= 0)
    //         throw new ArgumentOutOfRangeException(nameof(year), "Year must be positive.");

    //     if (netSalary < 0 ||
    //         grossSalary < 0 ||
    //         employeeSSContributionAmount < 0 ||
    //         employeeUnemploymentInsuranceContributionAmount < 0 ||
    //         cumulativeIncomeTaxBase < 0 ||
    //         incomeTaxBase < 0 ||
    //         incomeTax < 0 ||
    //         incomeTaxExemption < 0 ||
    //         stampTax < 0 ||
    //         employerSSContributionAmount < 0 ||
    //         employerUnemploymentInsuranceContributionAmount < 0 ||
    //         incentiveDiscount < 0 ||
    //         totalEmployerCost < 0)
    //     {
    //         throw new ArgumentOutOfRangeException("Monetary values cannot be negative.");
    //     }

    //     Employee = employee;
    //     Month = month;
    //     Year = year;

    //     NetSalary = netSalary;
    //     GrossSalary = grossSalary;

    //     EmployeeSSContributionAmount = employeeSSContributionAmount;
    //     EmployeeUnemploymentInsuranceContributionAmount = employeeUnemploymentInsuranceContributionAmount;

    //     CumulativeIncomeTaxBase = cumulativeIncomeTaxBase;
    //     IncomeTaxBase = incomeTaxBase;

    //     IncomeTax = incomeTax;
    //     IncomeTaxExemption = incomeTaxExemption;

    //     StampTax = stampTax;

    //     EmployerSSContributionAmount = employerSSContributionAmount;
    //     EmployerUnemploymentInsuranceContributionAmount = employerUnemploymentInsuranceContributionAmount;

    //     IncentiveDiscount = incentiveDiscount;
    //     TotalEmployerCost = totalEmployerCost;
    // }
}
