using System;
using System.IO.Pipelines;
using BudgetPay.Domain;

namespace BudgetPay.Application;

public static class SocialSecurityCalculator
{
    
    
    public static decimal EmployeeSocialSecurityResult(decimal GrossPayroll, SocialSecurityParameters socialSecurityParameters)
    {   
        if (socialSecurityParameters == null)
        {
            throw new ArgumentNullException(nameof(socialSecurityParameters), "Social security parameters cannot be null.");
        }

        if (GrossPayroll < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(GrossPayroll), "Gross payroll must be greater than 0.");
        }

        if (GrossPayroll > socialSecurityParameters.SocialSecurityCeiling)
        {
            return socialSecurityParameters.SocialSecurityCeiling * socialSecurityParameters.EmployeeSocialSecurityRate;
        }
        else
        {
            return GrossPayroll * socialSecurityParameters.EmployeeSocialSecurityRate;
        }
    }

    public static decimal EmployeeUnemploymentInsuranceResult(decimal GrossPayroll, SocialSecurityParameters socialSecurityParameters)
    {
        if (socialSecurityParameters == null)
        {
            throw new ArgumentNullException(nameof(socialSecurityParameters), "Social security parameters cannot be null.");
        }

        if (GrossPayroll < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(GrossPayroll), "Gross payroll must be greater than 0.");
        }


        if (GrossPayroll > socialSecurityParameters.SocialSecurityCeiling)
        {
            return socialSecurityParameters.SocialSecurityCeiling * socialSecurityParameters.EmployeeUnemploymentInsuranceRate;
        }
        else
        {
            return GrossPayroll * socialSecurityParameters.EmployeeUnemploymentInsuranceRate;
        }
    }

}
