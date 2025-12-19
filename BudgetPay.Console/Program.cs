
/*
using BudgetPay.Infrastructure;

var exporter = new EmployeeTemplateExcelExporter();

var workbook = exporter.GetTemplateWorkbook();

var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
var filePath = Path.Combine(desktopPath, "EmployeeTemplate.xlsx");

workbook.SaveAs(filePath);

Console.WriteLine("Employee template masaüstüne oluşturuldu.");
*/

using System.Collections.Generic;
using BudgetPay.Application;
using BudgetPay.Domain;
using BudgetPay.Infrastructure;
using DocumentFormat.OpenXml.Office.CustomUI;


// Statutory Payroll Parameters
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
SocialSecurityParameters ProgramSocialSecurityParameters = new SocialSecurityParameters(0.14m, 0.01m, 0.205m, 0.02m, 195041.40m);
StampTax ProgramStampTax = new StampTax(0.00759m);

StatutoryParameters.Initialize(ProgramSocialSecurityParameters, ProgramIncomeTaxBrackets, ProgramStampTax, ProgramMinimumWage);


PayrollCalculator calculator = new PayrollCalculator();

Employee gokhan = new();
gokhan.BaseSalary = 900000.00m;

List<MonthlyPayroll> liste = new();
EmployeeCumulativeTaxState state = new();
for (int i = 1; i <= 12; i++)
{

    MonthlyPayroll result = calculator.CalculateMonthlyFromGross(gokhan, state, i);
    state.AddMonthlyIncomeTaxBase(result.IncomeTaxBase);
    liste.Add(result);

}

foreach (MonthlyPayroll item in liste)
{
    Console.WriteLine($"{item.NetSalary, 13:N2}" +"  "+
                      $"{item.EmployeeSSContributionAmount, 13:N2}" +"  "+
                      $"{item.EmployeeUnemploymentInsuranceContributionAmount, 13:N2}" +"  "+
                      $"{item.IncomeTaxBase, 13:N2}" +"  "+
                      $"{item.CumulativeIncomeTaxBase, 13:N2}" +"  "+
                      $"{item.IncomeTax, 13:N2}" +"  "+
                      $"{item.StampTax, 13:N2}" +"  "+
                      $"{item.IncomeTaxExemption, 13:N2}" +"  "+
                      $"{item.StampExemption, 13:N2}" +"  "+
                      $"{item.GrossSalary, 13:N2}");
}






