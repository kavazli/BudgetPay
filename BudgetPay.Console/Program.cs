
/*
using BudgetPay.Infrastructure;

var exporter = new EmployeeTemplateExcelExporter();

var workbook = exporter.GetTemplateWorkbook();

var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
var filePath = Path.Combine(desktopPath, "EmployeeTemplate.xlsx");

workbook.SaveAs(filePath);

Console.WriteLine("Employee template masaüstüne oluşturuldu.");
*/

using BudgetPay.Application;
using BudgetPay.Domain;
using BudgetPay.Infrastructure; 

PayrollCalculator calculator = new PayrollCalculator();

var result = calculator.CalculateMonthlyFromGross(26005m, new EmployeeCumulativeTaxState(), 1);

Console.WriteLine($"Net Maaş: {result.NetSalary} TL");
System.Console.WriteLine($"İşsizlik Sigortası Kesintisi: {result.EmployeeUnemploymentInsuranceContributionAmount} TL");
System.Console.WriteLine($"SGK Kesintisi: {result.EmployeeSSContributionAmount} TL");
System.Console.WriteLine($"Gelir Vergisi Matrahı: {result.IncomeTaxBase} TL");
System.Console.WriteLine($"Gelir Vergisi: {result.IncomeTax} TL");
System.Console.WriteLine($"Damga Vergisi: {result.StampTax} TL");
System.Console.WriteLine($"Brüt Maaş: {result.GrossSalary} TL");
