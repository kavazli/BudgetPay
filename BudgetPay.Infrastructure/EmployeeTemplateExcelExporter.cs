
using ClosedXML.Excel;
namespace BudgetPay.Infrastructure;


// Excel şablon dosyasını oluşturan bir sınıf
public class EmployeeTemplateExcelExporter
{
    private static readonly string[] Headers = new[]
    {
        "FullName",
        "NationalIdNumber",
        "Department",
        "CostCenter",
        "PayType",
        "Status",
        "BaseSalary",
        "SalaryIncreaseRate",
        "PlannedMonthlyOvertimeHours",
        "PlannedBonusAmount",
        "BonusFrequency",
        "PlannedVoucherAmount",
        "VoucherFrequency"
    };
    
   // Şablon Excel dosyasını oluşturan metot
    public XLWorkbook GetTemplateWorkbook()
    {
        XLWorkbook TemplateWorkbook = new XLWorkbook();
        var worksheet = TemplateWorkbook.AddWorksheet("Employees");

        for (int i = 0; i < Headers.Length; i++)
        {
            var cell = worksheet.Cell(1, i + 1);
            cell.Value = Headers[i];
            cell.Style.Fill.BackgroundColor = XLColor.Gray;
        }
        
        worksheet.SheetView.FreezeRows(1);
        worksheet.RangeUsed()?.SetAutoFilter();
        worksheet.Columns().AdjustToContents();


        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string filePath = System.IO.Path.Combine(desktopPath, "ResultTable.xlsx");

        TemplateWorkbook.SaveAs(filePath);

        return TemplateWorkbook;
    }

}
