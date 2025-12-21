using System;

namespace BudgetPay.Domain;

public class SocialSecurityParameters
{
    public decimal EmployeeSocialSecurityRate { get; }
    public decimal EmployeeUnemploymentInsuranceRate { get; }
    public decimal EmployerSocialSecurityRate { get; }
    public decimal EmployerUnemploymentInsuranceRate { get; }
    public decimal SocialSecurityCeiling { get; }


    public SocialSecurityParameters(
        decimal employeeSocialSecurityRate,
        decimal employeeUnemploymentInsuranceRate,
        decimal employerSocialSecurityRate,
        decimal employerUnemploymentInsuranceRate,
        decimal socialSecurityCeiling)
    {
    

        EmployeeSocialSecurityRate = ValidateRate(employeeSocialSecurityRate, nameof(employeeSocialSecurityRate));
        EmployeeUnemploymentInsuranceRate = ValidateRate(employeeUnemploymentInsuranceRate, nameof(employeeUnemploymentInsuranceRate));
        EmployerSocialSecurityRate = ValidateRate(employerSocialSecurityRate, nameof(employerSocialSecurityRate));
        EmployerUnemploymentInsuranceRate = ValidateRate(employerUnemploymentInsuranceRate, nameof(employerUnemploymentInsuranceRate));


        if (socialSecurityCeiling <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(socialSecurityCeiling), "Social security ceiling must be greater than 0.");
        }
            
        SocialSecurityCeiling = socialSecurityCeiling;
    }

    private static decimal ValidateRate(decimal rate, string paramName)
    {
        if (rate <= 0 || rate >= 1)
            throw new ArgumentOutOfRangeException(paramName, "Rate must be greater than 0.");
        return rate;
    }


}
