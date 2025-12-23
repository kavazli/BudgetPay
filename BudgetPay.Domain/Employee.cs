
namespace BudgetPay.Domain;


// Dışarıdan veri alıp, veri tutmak için kullanılan entity
public class Employee
{
    public string FullName { get; set; } = string.Empty;
    public string NationalIdNumber { get; set; } = string.Empty;

    public string Department { get; set; } = string.Empty;
    public string CostCenter { get; set; } = string.Empty;
    public string PayType { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;

    public decimal BaseSalary { get; set; }
    public decimal SalaryIncreaseRate { get; set; }

    public decimal PlannedMonthlyOvertimeHours { get; set; }

    public decimal PlannedBonusAmount { get; set; }
    public decimal BonusFrequency { get; set; }

    public decimal PlannedVoucherAmount { get; set; }
    public decimal VoucherFrequency { get; set; }
}

