
/*
using BudgetPay.Infrastructure;

var exporter = new EmployeeTemplateExcelExporter();

var workbook = exporter.GetTemplateWorkbook();

var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
var filePath = Path.Combine(desktopPath, "EmployeeTemplate.xlsx");

workbook.SaveAs(filePath);

Console.WriteLine("Employee template masaüstüne oluşturuldu.");
*/

using System;
using System.Collections.Generic;
using BudgetPay.Application;
using BudgetPay.Domain;
using BudgetPay.Infrastructure;
using DocumentFormat.OpenXml.Office.CustomUI;


DateTime now = DateTime.Now;

// -------------- Statutory Payroll Parameters
List<IncomeTaxBracket> ProgramBrackets = new()
{
    new IncomeTaxBracket(0m, 158000m, 0.15m, 0m),
    new IncomeTaxBracket(158000.01m, 330000m, 0.20m, 23700m),
    new IncomeTaxBracket(330000.01m, 1200000m, 0.27m, 58000m),
    new IncomeTaxBracket(1200000.01m, 4300000m, 0.35m, 293000m),
    new IncomeTaxBracket(4300000.01m, decimal.MaxValue, 0.40m, 1378000m)
};

IncomeTaxBrackets ProgramIncomeTaxBrackets = new(ProgramBrackets);
MinimumWage ProgramMinimumWage = new MinimumWage(26005.50m, 22104.67m);
SocialSecurityParameters ProgramSocialSecurityParameters = new SocialSecurityParameters(0.14m, 0.01m, 0.1575m, 0.02m, 195041.40m);
StampTax ProgramStampTax = new StampTax(0.00759m);
// -------------- Statutory Payroll Parameters



StatutoryParameters.Initialize(ProgramSocialSecurityParameters, ProgramIncomeTaxBrackets, ProgramStampTax, ProgramMinimumWage);


EmployeeExcelImporter importer = new EmployeeExcelImporter();
List<Employee> employees = importer.ExcelImporter(@"C:\Users\gokhan.kaya\OneDrive - Aster Textile\Desktop\EmployeeTemplate.xlsx");



PayrollCalculator calculator = new PayrollCalculator();
List<MonthlyPayroll> result = new List<MonthlyPayroll>();
for(int i = 0; i < employees.Count; i++)
{
    var list = calculator.CalculateAnnualPayrollFromGross(employees[i]);
    result.AddRange(list); 
}

PayrollResultExcelExporter exporter = new PayrollResultExcelExporter();
var workbook = exporter.ExportToExcel(result);

DateTime end = DateTime.Now;
TimeSpan duration = end - now;

Console.WriteLine("çalişma süresi" + duration);

/*
foreach (MonthlyPayroll item in result)
{
    Console.WriteLine($"{item.Fullname, 10:N2}" +"  "+
                      $"{item.NetSalary, 10:N2}" +"  "+
                      $"{item.EmployeeSSContributionAmount, 10:N2}" +"  "+
                      $"{item.EmployeeUnemploymentInsuranceContributionAmount, 10:N2}" +"  "+
                      $"{item.IncomeTaxBase, 13:N2}" +"  "+
                      $"{item.CumulativeIncomeTaxBase, 13:N2}" +"  "+
                      $"{item.IncomeTax, 13:N2}" +"  "+
                      $"{item.StampTax, 10:N2}" +"  "+
                      $"{item.IncomeTaxExemption, 10:N2}" +"  "+
                      $"{item.StampExemption, 10:N2}" +"  "+
                      $"{item.GrossSalary, 10:N2}" +"  "+
                      $"{item.EmployerSSContributionAmount, 10:N2}" +"  "+
                      $"{item.EmployerUnemploymentInsuranceContributionAmount, 10:N2}" +"  "+
                      $"{item.TotalEmployerCost, 10:N2}");
}

PayrollResultExcelExporter exporter = new PayrollResultExcelExporter();
var workbook = exporter.ExportToExcel(result);

*/

// EmployeeTemplateExcelExporter templateExporter = new EmployeeTemplateExcelExporter();
// var templateWorkbook = templateExporter.GetTemplateWorkbook();