
using BudgetPay.Application;
using BudgetPay.Domain;


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


// Initialize Statutory Parameters
StatutoryParameters.Initialize(ProgramSocialSecurityParameters, ProgramIncomeTaxBrackets, ProgramStampTax, ProgramMinimumWage);



PayrollExcelWorkflow workflow = new PayrollExcelWorkflow(@"/Users/gokhankaya/Desktop/ResultTable.xlsx");
workflow.Run();

DateTime end = DateTime.Now;
TimeSpan duration = end - now;

Console.WriteLine("çalişma süresi" + duration);

