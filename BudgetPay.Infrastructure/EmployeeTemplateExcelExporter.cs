using System;
using ClosedXML.Excel;

namespace BudgetPay.Infrastructure;

public class EmployeeTemplateExcelExporter
{
    private static readonly string[] Headers = new[]
    {
        "FullName",
        "NationalIdNumber",
        "Department",
        "CostCenter",
        "PayType",
        "BaseSalary",
        "SalaryIncreaseRate",
        "PlannedMonthlyOvertimeHours",
        "PlannedBonusAmount",
        "BonusFrequency",
        "PlannedVoucherAmount",
        "VoucherFrequency"
    };
    
   
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

        return TemplateWorkbook;
    }

}
