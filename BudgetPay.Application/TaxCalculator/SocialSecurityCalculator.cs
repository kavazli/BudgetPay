
namespace BudgetPay.Application;


// Sosyal Güvenlik Kesintilerini hesaplayan sınıf
public static class SocialSecurityCalculator
{
    


    // Çalışan sosyal güvenlik kesintisini hesaplayan metot
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

        // Tavan maaş kontrolü
        if (GrossPayroll > StatutoryParameters.SocialSecurityParameters.SocialSecurityCeiling)
        {
            return StatutoryParameters.SocialSecurityParameters.SocialSecurityCeiling * StatutoryParameters.SocialSecurityParameters.EmployeeSocialSecurityRate;
        }
        else
        {   // Normal maaş için hesaplama
            return GrossPayroll * StatutoryParameters.SocialSecurityParameters.EmployeeSocialSecurityRate;
        }
    }
    
    // Emekli çalışan sosyal güvenlik kesintisini hesaplayan metot
    public static decimal RetiredEmployeeSocialSecurityResult(decimal GrossPayroll)
    {   

        if (StatutoryParameters.SocialSecurityParameters == null)
        {
            throw new ArgumentNullException(nameof(StatutoryParameters.SocialSecurityParameters), "Social security parameters cannot be null.");
        }


        if (GrossPayroll < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(GrossPayroll), "Gross payroll must be greater than 0.");
        }

        // Tavan maaş kontrolü
        if (GrossPayroll > StatutoryParameters.SocialSecurityParameters.SocialSecurityCeiling)
        {
            return StatutoryParameters.SocialSecurityParameters.SocialSecurityCeiling * StatutoryParameters.SocialSecurityParameters.RetiredEmployeeSocialSecurityRate;
        }
        else
        {   // Normal maaş için hesaplama
            return GrossPayroll * StatutoryParameters.SocialSecurityParameters.RetiredEmployeeSocialSecurityRate;
        }
    }


    // Çalışan işsizlik sigortası kesintisini hesaplayan metot
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

        // Tavan maaş kontrolü
        if (GrossPayroll > StatutoryParameters.SocialSecurityParameters.SocialSecurityCeiling)
        {
            return StatutoryParameters.SocialSecurityParameters.SocialSecurityCeiling * StatutoryParameters.SocialSecurityParameters.EmployeeUnemploymentInsuranceRate;
        }
        else
        {   // Normal maaş için hesaplama
            return GrossPayroll * StatutoryParameters.SocialSecurityParameters.EmployeeUnemploymentInsuranceRate;
        }
    }




    // İşveren sosyal güvenlik kesintisini hesaplayan metot
    public static decimal EmployerSocialSecurityResult(decimal GrossPayroll)
    {   

        if (StatutoryParameters.SocialSecurityParameters == null)
        {
            throw new ArgumentNullException(nameof(StatutoryParameters.SocialSecurityParameters), "Social security parameters cannot be null.");
        }

        if (GrossPayroll < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(GrossPayroll), "Gross payroll must be greater than 0.");
        }

        // Tavan maaş kontrolü
        if (GrossPayroll > StatutoryParameters.SocialSecurityParameters.SocialSecurityCeiling)
        {
            return StatutoryParameters.SocialSecurityParameters.SocialSecurityCeiling * StatutoryParameters.SocialSecurityParameters.EmployerSocialSecurityRate;
        }
        else
        {   // Normal maaş için hesaplama
            return GrossPayroll * StatutoryParameters.SocialSecurityParameters.EmployerSocialSecurityRate;
        }
    }


    // Emekli işveren sosyal güvenlik kesintisini hesaplayan metot
    public static decimal RetiredEmployerSocialSecurityResult(decimal GrossPayroll)
    {   

        if (StatutoryParameters.SocialSecurityParameters == null)
        {
            throw new ArgumentNullException(nameof(StatutoryParameters.SocialSecurityParameters), "Social security parameters cannot be null.");
        }

        if (GrossPayroll < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(GrossPayroll), "Gross payroll must be greater than 0.");
        }

        // Tavan maaş kontrolü
        if (GrossPayroll > StatutoryParameters.SocialSecurityParameters.SocialSecurityCeiling)
        {
            return StatutoryParameters.SocialSecurityParameters.SocialSecurityCeiling * StatutoryParameters.SocialSecurityParameters.RetiredEmployerSocialSecurityRate;
        }
        else
        {   // Normal maaş için hesaplama
            return GrossPayroll * StatutoryParameters.SocialSecurityParameters.RetiredEmployerSocialSecurityRate;
        }
    }

    
    // İşveren işsizlik sigortası kesintisini hesaplayan metot    
    public static decimal EmployerUnemploymentInsuranceResult(decimal GrossPayroll)
    {   

        if (StatutoryParameters.SocialSecurityParameters == null)
        {
            throw new ArgumentNullException(nameof(StatutoryParameters.SocialSecurityParameters), "Social security parameters cannot be null.");
        }

        if (GrossPayroll < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(GrossPayroll), "Gross payroll must be greater than 0.");
        }

        // Tavan maaş kontrolü
        if (GrossPayroll > StatutoryParameters.SocialSecurityParameters.SocialSecurityCeiling)
        {
            return StatutoryParameters.SocialSecurityParameters.SocialSecurityCeiling * StatutoryParameters.SocialSecurityParameters.EmployerUnemploymentInsuranceRate;
        }
        else
        {   // Normal maaş için hesaplama
            return GrossPayroll * StatutoryParameters.SocialSecurityParameters.EmployerUnemploymentInsuranceRate;
        }
    }

}
