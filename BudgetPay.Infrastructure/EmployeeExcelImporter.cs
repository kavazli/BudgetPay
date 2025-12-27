
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
            employee.SalaryIncreaseRate = 0m;
            employee.PlannedMonthlyOvertimeHours =0m;
            employee.PlannedBonusAmount = 0m;
            employee.BonusFrequency = 0;
            employee.PlannedVoucherAmount = 0;
            employee.VoucherFrequency = 0;
            Employees.Add(employee);
        
    }

    return Employees;
    }
}
