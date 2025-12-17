using System;
using System.Runtime.InteropServices;
using BudgetPay.Domain;

namespace BudgetPay.Application;

public static class StampTaxCalculator
{   
    public static StampTax DefaultStampTax => new StampTax(0.00759m);
    public static decimal CalculeteStampTax(decimal grossSalary, StampTax stampTax)
    {   
        if(grossSalary < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(grossSalary), "Gross salary must be greater than 0.");
        }

        return grossSalary * stampTax.Rate;
    }
}
