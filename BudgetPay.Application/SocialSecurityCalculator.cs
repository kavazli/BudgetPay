using System;
using System.IO.Pipelines;
using BudgetPay.Domain;

namespace BudgetPay.Application;

public static class SocialSecurityCalculator
{
    
    
    public static decimal EmployeeSocialSecurityResult(decimal GrossPayroll)
    {   
        if (StatutoryParameters.SocialSecurityParameters == null)
        {
            throw new ArgumentNullException(nameof(StatutoryParameters.SocialSecurityParameters), "Social security parameters cannot be null.");
        }

        if (GrossPayroll < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(GrossPayroll), "Gross payroll must be greater than 0.");
        }

        if (GrossPayroll > StatutoryParameters.SocialSecurityParameters.SocialSecurityCeiling)
        {
            return StatutoryParameters.SocialSecurityParameters.SocialSecurityCeiling * StatutoryParameters.SocialSecurityParameters.EmployeeSocialSecurityRate;
        }
        else
        {
            return GrossPayroll * StatutoryParameters.SocialSecurityParameters.EmployeeSocialSecurityRate;
        }
    }

    public static decimal EmployeeUnemploymentInsuranceResult(decimal GrossPayroll)
    {
        if (StatutoryParameters.SocialSecurityParameters == null)
        {
            throw new ArgumentNullException(nameof(StatutoryParameters.SocialSecurityParameters), "Social security parameters cannot be null.");
        }

        if (GrossPayroll < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(GrossPayroll), "Gross payroll must be greater than 0.");
        }


        if (GrossPayroll > StatutoryParameters.SocialSecurityParameters.SocialSecurityCeiling)
        {
            return StatutoryParameters.SocialSecurityParameters.SocialSecurityCeiling * StatutoryParameters.SocialSecurityParameters.EmployeeUnemploymentInsuranceRate;
        }
        else
        {
            return GrossPayroll * StatutoryParameters.SocialSecurityParameters.EmployeeUnemploymentInsuranceRate;
        }
    }

}
