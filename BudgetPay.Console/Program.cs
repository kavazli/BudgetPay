
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
gokhan.BaseSalary = 22104.67m;

MonthlyPayroll result = calculator.CalculateMonthlyFromGross(gokhan, new EmployeeCumulativeTaxState(), 1);

Console.WriteLine($"Net Maaş:                     {result.NetSalary, 10 } TL");
Console.WriteLine($"İşsizlik Sigortası Kesintisi: {result.EmployeeUnemploymentInsuranceContributionAmount, 10} TL");
Console.WriteLine($"SGK Kesintisi:                {result.EmployeeSSContributionAmount,10} TL");
Console.WriteLine($"K.Gelir Vergisi Matrahı:      {result.CumulativeIncomeTaxBase, 10} TL");
Console.WriteLine($"Gelir Vergisi Matrahı:        {result.IncomeTaxBase, 10} TL");
Console.WriteLine($"Gelir Vergisi:                {result.IncomeTax, 10} TL");
Console.WriteLine($"Damga Vergisi:                {result.StampTax, 10} TL");
Console.WriteLine($"Brüt Maaş:                    {result.GrossSalary, 10} TL");

