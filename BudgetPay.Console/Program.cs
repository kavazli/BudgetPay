
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


Employee employee = new Employee
{
    FullName = "John Doe",
    NationalIdNumber = "12345678901",
    Department = "Finance",
    CostCenter = "FC1001",
    PayType = "Monthly",
    Status = "Active",
    BaseSalary = 150000m
    
};

PayrollCalculator calculator = new PayrollCalculator();

EmployeeCumulativeTaxState state = new EmployeeCumulativeTaxState();
{
    state.CumulativeIncomeTaxBase = 0m;
}


MonthlyPayroll pay = new MonthlyPayroll();

decimal netUcret =employee.BaseSalary;
decimal fark = 0m;
decimal tolerans = 0.00001m;


for(int i=0; i < 200; i++)
{

    pay = calculator.CalculateMonthlyPayrollFromGross(employee, state, 1);
    fark = netUcret - pay.NetSalary;
    if(fark < tolerans)
    {
        break;
    }
    
    if(fark > tolerans)
    {
        employee.BaseSalary = pay.GrossSalary + fark;
    }

   
}

// System.Console.WriteLine($"{pay.GrossSalary:f2} - {Math.Ceiling(pay.NetSalary):f2}");

System.Console.WriteLine($"Brüt Ücret: {pay.GrossSalary:f2}");
System.Console.WriteLine($"SGK İşçi Payı: {pay.EmployeeSSContributionAmount:f2}");
System.Console.WriteLine($"İşsizlik Sigortası İşçi Payı: {pay.EmployeeUnemploymentInsuranceContributionAmount:f2}");
System.Console.WriteLine($"Gelir kümülatif Matrahı: {pay.CumulativeIncomeTaxBase:f2}");
System.Console.WriteLine($"Gelir Vergisi Matrahı: {pay.IncomeTaxBase:f2}");
System.Console.WriteLine($"Gelir Vergisi: {pay.IncomeTax:f2}");
System.Console.WriteLine($"Damga Vergisi: {pay.StampTax:f2}");
System.Console.WriteLine($"Gelir Vergisi Muafiyeti: {pay.IncomeTaxExemption:f2}");
System.Console.WriteLine($"Damga Vergisi Muafiyeti: {pay.StampExemption:f2}");

System.Console.WriteLine($"Net Ücret: {pay.NetSalary:f2}");







// PayrollExcelWorkflow workflow = new PayrollExcelWorkflow(@"C:\Users\gokhan.kaya\OneDrive - Aster Textile\Desktop\EmployeeTemplate.xlsx");
// workflow.Run();

// DateTime end = DateTime.Now;
// TimeSpan duration = end - now;

// Console.WriteLine("çalişma süresi" + duration);

