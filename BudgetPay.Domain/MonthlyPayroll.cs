using System;

namespace BudgetPay.Domain;

public class MonthlyPayroll
{
    public Employee Employee { get; }
    public int Month { get; }
    public int Year { get; }

    public decimal NetSalary { get; }
    public decimal GrossSalary { get; }

    public decimal EmployeeSSContributionAmount { get; }
    public decimal EmployeeUnemploymentInsuranceContributionAmount { get; }

    public decimal CumulativeIncomeTaxBase { get; }
    public decimal IncomeTaxBase { get; }

    public decimal IncomeTax { get; }
    public decimal IncomeTaxExemption { get; }

    public decimal StampTax { get; }

    public decimal EmployerSSContributionAmount { get; }
    public decimal EmployerUnemploymentInsuranceContributionAmount { get; }

    public decimal IncentiveDiscount { get; }

    public decimal TotalEmployerCost { get; }

    internal MonthlyPayroll( 
        Employee employee,
        int month,
        int year,
        decimal netSalary,
        decimal grossSalary,
        decimal employeeSSContributionAmount,
        decimal employeeUnemploymentInsuranceContributionAmount,
        decimal cumulativeIncomeTaxBase,
        decimal incomeTaxBase,
        decimal incomeTax,
        decimal incomeTaxExemption,
        decimal stampTax,
        decimal employerSSContributionAmount,
        decimal employerUnemploymentInsuranceContributionAmount,
        decimal incentiveDiscount,
        decimal totalEmployerCost)
    {
        
        if (employee == null)
            throw new ArgumentNullException(nameof(employee));

        if (month < 1 || month > 12)
            throw new ArgumentOutOfRangeException(nameof(month), "Month must be between 1 and 12.");

        if (year <= 0)
            throw new ArgumentOutOfRangeException(nameof(year), "Year must be positive.");

        if (netSalary < 0 ||
            grossSalary < 0 ||
            employeeSSContributionAmount < 0 ||
            employeeUnemploymentInsuranceContributionAmount < 0 ||
            cumulativeIncomeTaxBase < 0 ||
            incomeTaxBase < 0 ||
            incomeTax < 0 ||
            incomeTaxExemption < 0 ||
            stampTax < 0 ||
            employerSSContributionAmount < 0 ||
            employerUnemploymentInsuranceContributionAmount < 0 ||
            incentiveDiscount < 0 ||
            totalEmployerCost < 0)
        {
            throw new ArgumentOutOfRangeException("Monetary values cannot be negative.");
        }

        Employee = employee;
        Month = month;
        Year = year;

        NetSalary = netSalary;
        GrossSalary = grossSalary;

        EmployeeSSContributionAmount = employeeSSContributionAmount;
        EmployeeUnemploymentInsuranceContributionAmount = employeeUnemploymentInsuranceContributionAmount;

        CumulativeIncomeTaxBase = cumulativeIncomeTaxBase;
        IncomeTaxBase = incomeTaxBase;

        IncomeTax = incomeTax;
        IncomeTaxExemption = incomeTaxExemption;

        StampTax = stampTax;

        EmployerSSContributionAmount = employerSSContributionAmount;
        EmployerUnemploymentInsuranceContributionAmount = employerUnemploymentInsuranceContributionAmount;

        IncentiveDiscount = incentiveDiscount;
        TotalEmployerCost = totalEmployerCost;
    }
}
