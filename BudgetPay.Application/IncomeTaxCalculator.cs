using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Pipelines;
using System.Runtime.CompilerServices;
using BudgetPay.Domain;

namespace BudgetPay.Application;

public static class IncomeTaxCalculator
{

    public static decimal CalculateTax(decimal taxbase,EmployeeCumulativeTaxState state)
    {   

        if (state == null)
        {
            throw new ArgumentNullException(nameof(state), "Employee cumulative tax state cannot be null.");
        }
        if (taxbase < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(taxbase), "Tax base cannot be negative.");
        }

        decimal previousBase = state.CumulativeIncomeTaxBase;
        decimal curreBase = previousBase + taxbase;

        decimal taxPreviousBase = TaxBracketCalculation(previousBase);
        decimal taxCurrentBase = TaxBracketCalculation(curreBase);  
        decimal tax = taxCurrentBase - taxPreviousBase;
        return tax;
    }
    

    private static decimal TaxBracketCalculation(decimal totalBase)
    {
        
    if (StatutoryParameters.IncomeTaxBrackets == null)
        {
            throw new ArgumentNullException(nameof(StatutoryParameters.IncomeTaxBrackets), "Income tax brackets cannot be null.");
        }

    if (StatutoryParameters.IncomeTaxBrackets.Brackets == null || StatutoryParameters.IncomeTaxBrackets.Brackets.Count == 0)
    {
        throw new ArgumentException("Tax brackets cannot be empty.", nameof(StatutoryParameters.IncomeTaxBrackets));
    }

    if (totalBase <= 0)
    {
        return 0m;
    }

    decimal tax = 0m;

    for (int i = 0; i < StatutoryParameters.IncomeTaxBrackets.Brackets.Count; i++)
    {
        decimal bracketMin = (i == 0) ? 0m : StatutoryParameters.IncomeTaxBrackets.Brackets[i - 1].MaxAmount;
        decimal bracketMax = StatutoryParameters.IncomeTaxBrackets.Brackets[i].MaxAmount;

        if (totalBase <= bracketMin)
        {
            break;
        }

        if (totalBase > bracketMax)
        {
            tax += (bracketMax - bracketMin) * StatutoryParameters.IncomeTaxBrackets.Brackets[i].Rate;
        }
        else
        {
            tax += (totalBase - bracketMin) * StatutoryParameters.IncomeTaxBrackets.Brackets[i].Rate;
            break;
        }
    }

    return tax;
    }

}

    