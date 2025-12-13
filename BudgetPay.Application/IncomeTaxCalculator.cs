using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Pipelines;
using System.Runtime.CompilerServices;
using BudgetPay.Domain;

namespace BudgetPay.Application;

public static class IncomeTaxCalculator
{

    public static decimal CalculateTax(decimal taxbase, IncomeTaxBrackets brackets, EmployeeCumulativeTaxState state)
    {   
        decimal previousBase = state.CumulativeIncomeTaxBase;
        decimal curreBase = previousBase + taxbase;

        decimal taxPreviousBase = TaxBracketCalculation(previousBase, brackets);
        decimal taxCurrentBase = TaxBracketCalculation(curreBase, brackets);  
        decimal tax = taxCurrentBase - taxPreviousBase;
        return tax;
    }
    

    private static decimal TaxBracketCalculation(decimal totalBase, IncomeTaxBrackets brackets)
{
    if (brackets == null)
    {
        throw new ArgumentNullException(nameof(brackets), "Income tax brackets cannot be null.");
    }

    if (brackets.Brackets == null || brackets.Brackets.Count == 0)
    {
        throw new ArgumentException("Tax brackets cannot be empty.", nameof(brackets));
    }

    if (totalBase <= 0)
    {
        return 0m;
    }

    decimal tax = 0m;

    for (int i = 0; i < brackets.Brackets.Count; i++)
    {
        decimal bracketMin = (i == 0) ? 0m : brackets.Brackets[i - 1].MaxAmount;
        decimal bracketMax = brackets.Brackets[i].MaxAmount;

        if (totalBase <= bracketMin)
        {
            break;
        }

        if (totalBase > bracketMax)
        {
            tax += (bracketMax - bracketMin) * brackets.Brackets[i].Rate;
        }
        else
        {
            tax += (totalBase - bracketMin) * brackets.Brackets[i].Rate;
            break;
        }
    }

    return tax;
}

}

    