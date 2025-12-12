using System;
using BudgetPay.Domain;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;

namespace BudgetPay.Infrastructure;

public class PayrollResultExcelExporter
{
    private Dictionary<string, List<MonthlyPayroll>> _payrolls;
    
    private readonly string[] Headers = new string[]
    {
        "Employee Name",
        "Month",
        "Year",
        "Net Salary",
        "Gross Salary",
        "Employee SS Contribution",
        "Employee Unemployment Insurance Contribution",
        "Cumulative Income Tax Base",
        "Income Tax Base",
        "Income Tax",
        "Income Tax Exemption",
        "Stamp Tax",
        "Employer SS Contribution",
        "Employer Unemployment Insurance Contribution",
        "Incentive Discount",
        "Total Employer Cost"
    };

    public PayrollResultExcelExporter(Dictionary<string, List<MonthlyPayroll>> payrolls)
    {   
        _payrolls = new Dictionary<string, List<MonthlyPayroll>>(payrolls);
        
    }

    
    public XLWorkbook ExportToExcel()
{
    var workbook = PayrollResultExcelHeaders(Headers);
    var worksheet = workbook.Worksheet("Payroll Results");

    int row = 2; // 1. satır header, veriler 2. satırdan başlar

    // Çalışanları isim sırasına göre stabil gezmek için:
    // (İstersen key'e göre: OrderBy(x => x.Key) yapabilirsin.)
    foreach (var kvp in _payrolls
        .Where(x => x.Value != null && x.Value.Count > 0)
        .OrderBy(x => x.Value[0].Employee.FullName))
    {
        // Aynı çalışanın bordrolarını Yıl + Ay sırasına göre yaz
        foreach (var payroll in kvp.Value
            .OrderBy(p => p.Year)
            .ThenBy(p => p.Month))
        {
            worksheet.Cell(row, 1).Value  = payroll.Employee.FullName;
            worksheet.Cell(row, 2).Value  = payroll.Month;
            worksheet.Cell(row, 3).Value  = payroll.Year;
            worksheet.Cell(row, 4).Value  = payroll.NetSalary;
            worksheet.Cell(row, 5).Value  = payroll.GrossSalary;
            worksheet.Cell(row, 6).Value  = payroll.EmployeeSSContributionAmount;
            worksheet.Cell(row, 7).Value  = payroll.EmployeeUnemploymentInsuranceContributionAmount;
            worksheet.Cell(row, 8).Value  = payroll.CumulativeIncomeTaxBase;
            worksheet.Cell(row, 9).Value  = payroll.IncomeTaxBase;
            worksheet.Cell(row, 10).Value = payroll.IncomeTax;
            worksheet.Cell(row, 11).Value = payroll.IncomeTaxExemption;
            worksheet.Cell(row, 12).Value = payroll.StampTax;
            worksheet.Cell(row, 13).Value = payroll.EmployerSSContributionAmount;
            worksheet.Cell(row, 14).Value = payroll.EmployerUnemploymentInsuranceContributionAmount;
            worksheet.Cell(row, 15).Value = payroll.IncentiveDiscount;
            worksheet.Cell(row, 16).Value = payroll.TotalEmployerCost;

            row++; // her bordro bir satır!
        }
    }

    worksheet.SheetView.FreezeRows(1);
    worksheet.RangeUsed()?.SetAutoFilter();
    worksheet.Columns().AdjustToContents();

    return workbook;
}
    

    private XLWorkbook PayrollResultExcelHeaders(string[] headers)
    {
        var HeadersExcel = new XLWorkbook();
        var worksheet = HeadersExcel.AddWorksheet("Payroll Results");
        
        for (int i = 0; i < headers.Length; i++)
        {
            var cell = worksheet.Cell(1, i + 1);
            cell.Value = headers[i];
            cell.Style.Fill.BackgroundColor = XLColor.Gray;
        }


        return HeadersExcel;
    }
    

}
