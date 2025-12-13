using System;
using BudgetPay.Domain;
using ClosedXML.Excel;

namespace BudgetPay.Infrastructure;

public class PayrollResultExcelExporter
{
    private List<EmployeeAnnualPayroll> _employeeAnnualPayrolls;
    
    
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

    public PayrollResultExcelExporter(List<EmployeeAnnualPayroll> employeeAnnualPayrolls)
    {   

        if( employeeAnnualPayrolls == null )
        {
            throw new ArgumentNullException(nameof(employeeAnnualPayrolls), "Employee annual payrolls cannot be null.");
        }
        _employeeAnnualPayrolls = new List<EmployeeAnnualPayroll>(employeeAnnualPayrolls);
        
    }

    
    public XLWorkbook ExportToExcel()
    {
    var workbook = PayrollResultExcelHeaders(Headers);
    var worksheet = workbook.Worksheet("Payroll Results");

    int row = 2;

    for(int i = 0; i < _employeeAnnualPayrolls.Count; i++)
    {
        var annualPayroll = _employeeAnnualPayrolls[i];
        for(int j = 0; j < annualPayroll.AnnualPayrolls.Count; j++)
        {
            var monthlyPayroll = annualPayroll.AnnualPayrolls[j];
            worksheet.Cell(row, 1).Value  = monthlyPayroll.Employee.FullName;
            worksheet.Cell(row, 2).Value  = monthlyPayroll.Month;
            worksheet.Cell(row, 3).Value  = monthlyPayroll.Year;
            worksheet.Cell(row, 4).Value  = monthlyPayroll.NetSalary;
            worksheet.Cell(row, 5).Value  = monthlyPayroll.GrossSalary;
            worksheet.Cell(row, 6).Value  = monthlyPayroll.EmployeeSSContributionAmount;
            worksheet.Cell(row, 7).Value  = monthlyPayroll.EmployeeUnemploymentInsuranceContributionAmount;
            worksheet.Cell(row, 8).Value  = monthlyPayroll.CumulativeIncomeTaxBase;
            worksheet.Cell(row, 9).Value  = monthlyPayroll.IncomeTaxBase;
            worksheet.Cell(row, 10).Value = monthlyPayroll.IncomeTax;
            worksheet.Cell(row, 11).Value = monthlyPayroll.IncomeTaxExemption;
            worksheet.Cell(row, 12).Value = monthlyPayroll.StampTax;
            worksheet.Cell(row, 13).Value = monthlyPayroll.EmployerSSContributionAmount;
            worksheet.Cell(row, 14).Value = monthlyPayroll.EmployerUnemploymentInsuranceContributionAmount;
            worksheet.Cell(row, 15).Value = monthlyPayroll.IncentiveDiscount;
            worksheet.Cell(row, 16).Value = monthlyPayroll.TotalEmployerCost;

            row++;
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


