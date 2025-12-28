
using BudgetPay.Domain;
using ClosedXML.Excel;

namespace BudgetPay.Infrastructure;

// Payroll sonuçlarını Excel dosyasına aktaran bir sınıf
public class PayrollResultExcelExporter
{
    
    
    
    private readonly string[] Headers = new string[]
    {
        "Employee Name",
        "National ID Number",
        "Department",
        "Cost Center",
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
        "Stamp Exemption",
        "Employer SS Contribution",
        "Employer Unemployment Insurance Contribution",
        "Incentive Discount",
        "Total Employer Cost"
    };

    

    // Excel dosyasına aktarma metodu
    public XLWorkbook ExportToExcel(List<MonthlyPayroll> _employeeAnnualPayrolls)
    {
    var workbook = PayrollResultExcelHeaders(Headers);
    var worksheet = workbook.Worksheet("Payroll Results");

    int row = 2;

    //
    for(int i = 0; i < _employeeAnnualPayrolls.Count; i++)
    {
        var monthlyPayroll = _employeeAnnualPayrolls[i];
        worksheet.Cell(row, 1).Value  = monthlyPayroll.Fullname;
        worksheet.Cell(row, 2).Value  = monthlyPayroll.NationalIdNumber;
        worksheet.Cell(row, 3).Value  = monthlyPayroll.Department;
        worksheet.Cell(row, 4).Value  = monthlyPayroll.CostCenter;
        worksheet.Cell(row, 5).Value  = monthlyPayroll.Month;
        worksheet.Cell(row, 6).Value  = monthlyPayroll.Year;
        worksheet.Cell(row, 7).Value  = monthlyPayroll.NetSalary;
        worksheet.Cell(row, 7).Style.NumberFormat.Format = "#,##0.00";
        worksheet.Cell(row, 8).Value  = monthlyPayroll.GrossSalary;
        worksheet.Cell(row, 8).Style.NumberFormat.Format = "#,##0.00";
        worksheet.Cell(row, 9).Value  = monthlyPayroll.EmployeeSSContributionAmount;
        worksheet.Cell(row, 9).Style.NumberFormat.Format = "#,##0.00";
        worksheet.Cell(row, 10).Value = monthlyPayroll.EmployeeUnemploymentInsuranceContributionAmount;
        worksheet.Cell(row, 10).Style.NumberFormat.Format = "#,##0.00";
        worksheet.Cell(row, 11).Value = monthlyPayroll.CumulativeIncomeTaxBase;
        worksheet.Cell(row, 11).Style.NumberFormat.Format = "#,##0.00";
        worksheet.Cell(row, 12).Value = monthlyPayroll.IncomeTaxBase;
        worksheet.Cell(row, 12).Style.NumberFormat.Format = "#,##0.00";
        worksheet.Cell(row, 13).Value = monthlyPayroll.IncomeTax;
        worksheet.Cell(row, 13).Style.NumberFormat.Format = "#,##0.00";
        worksheet.Cell(row, 14).Value = monthlyPayroll.IncomeTaxExemption;
        worksheet.Cell(row, 14).Style.NumberFormat.Format = "#,##0.00";
        worksheet.Cell(row, 15).Value = monthlyPayroll.StampTax;
        worksheet.Cell(row, 15).Style.NumberFormat.Format = "#,##0.00";
        worksheet.Cell(row, 16).Value = monthlyPayroll.StampExemption;
        worksheet.Cell(row, 16).Style.NumberFormat.Format = "#,##0.00";
        worksheet.Cell(row, 17).Value = monthlyPayroll.EmployerSSContributionAmount;
        worksheet.Cell(row, 17).Style.NumberFormat.Format = "#,##0.00";
        worksheet.Cell(row, 18).Value = monthlyPayroll.EmployerUnemploymentInsuranceContributionAmount;
        worksheet.Cell(row, 18).Style.NumberFormat.Format = "#,##0.00";
        worksheet.Cell(row, 19).Value = monthlyPayroll.IncentiveDiscount;
        worksheet.Cell(row, 19).Style.NumberFormat.Format = "#,##0.00";
        worksheet.Cell(row, 20).Value = monthlyPayroll.TotalEmployerCost;
        worksheet.Cell(row, 20).Style.NumberFormat.Format = "#,##0.00";
        row++;
        
    }
    
    // Excel dosyasını düzenleme
    worksheet.SheetView.FreezeRows(1);
    worksheet.RangeUsed()?.SetAutoFilter();
    worksheet.Columns().AdjustToContents();

    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    string filePath = System.IO.Path.Combine(desktopPath, "PayrollResults.xlsx");
    workbook.SaveAs(filePath);

    return workbook;
}
    
    // Excel başlıklarını oluşturan metot
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


