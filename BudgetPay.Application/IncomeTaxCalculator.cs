using System;
using System.IO.Pipelines;
using BudgetPay.Domain;

namespace BudgetPay.Application;

public static class IncomeTaxCalculator
{
    

    public static decimal CalculateTax(decimal taxbase, IncomeTaxBrackets brackets, EmployeeCumulativeTaxState state)
    {
        return
    }


    private static decimal BraketOne(decimal taxbase, IncomeTaxBrackets brackets, EmployeeCumulativeTaxState state)
    {   
        
        decimal result;
        decimal TaxBase = state.CumulativeIncomeTaxBase + taxbase;
        if(taxbase <= brackets.Brackets[0].MaxAmount)
        {
            result = taxbase * brackets.Brackets[0].Rate;
            return result;
        }
        else
        {
            result = brackets.Brackets[0].MaxAmount * brackets.Brackets[0].Rate;
            return result;
        }            
    }













}
