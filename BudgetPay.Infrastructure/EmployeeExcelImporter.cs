
using BudgetPay.Domain;
namespace BudgetPay.Infrastructure;


// Excel dosyasından çalışan verilerini okuyup Employee nesnelerine dönüştüren bir sınıf
public class EmployeeExcelImporter
{

    // Excel dosyasını okuyup Employee nesnelerinin listesini döndüren metot
    public List<Employee> ExcelImporter(string filePath)
    {  

        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentNullException(nameof(filePath), "File path cannot be null.");
        }
        if(!File.Exists(filePath))
        {
            throw new FileNotFoundException("The specified file was not found.", filePath);
        }

        using var workbook = ClosedXML.Excel.XLWorkbook.OpenFromTemplate(filePath);
        var worksheet = workbook.Worksheet("Employees"); // Assuming data is in the first worksheet

        var LastRow = worksheet.LastRowUsed()?.RowNumber() ?? 0;

        var Employees = new List<Employee>();

        // Excel dosyasındaki her satırı okuyup Employee nesnesine dönüştürme
        for(int row = 2; row <= LastRow; row++)
        {

            if(worksheet.Row(row).IsEmpty())
            {
                continue;
            }

            var employee = new Employee();
            employee.FullName = worksheet.Cell(row, 1).GetString().Trim();
            employee.NationalIdNumber = worksheet.Cell(row, 2).GetString().Trim();
            employee.Department = worksheet.Cell(row, 3).GetString().Trim();
            employee.CostCenter = worksheet.Cell(row, 4).GetString().Trim();
            employee.PayType = worksheet.Cell(row, 5).GetString().Trim();
            employee.BaseSalary = decimal.TryParse(worksheet.Cell(row, 6).GetString().Trim(), out var baseSalary) ? baseSalary : 0;
            employee.SalaryIncreaseRate = decimal.TryParse(worksheet.Cell(row, 7).GetString().Trim(), out var salaryIncreaseRate) ? salaryIncreaseRate : 0;
            employee.PlannedMonthlyOvertimeHours = decimal.TryParse(worksheet.Cell(row, 8).GetString().Trim(), out var plannedMonthlyOvertimeHours) ? plannedMonthlyOvertimeHours : 0;
            employee.PlannedBonusAmount = decimal.TryParse(worksheet.Cell(row, 9).GetString().Trim(), out var plannedBonusAmount) ? plannedBonusAmount : 0;
            employee.BonusFrequency = int.TryParse(worksheet.Cell(row, 10).GetString().Trim(), out var bonusFrequency) ? bonusFrequency : 0;
            employee.PlannedVoucherAmount = decimal.TryParse(worksheet.Cell(row, 11).GetString().Trim(), out var plannedVoucherAmount) ? plannedVoucherAmount : 0;
            employee.VoucherFrequency = int.TryParse(worksheet.Cell(row, 12).GetString().Trim(), out var voucherFrequency) ? voucherFrequency : 0;
            Employees.Add(employee);
        
    }

    return Employees;
    
    }
}
