
using BudgetPay.Domain;
using BudgetPay.Infrastructure;


namespace BudgetPay.Application;

// Bordro işlemlerini Excel dosyası üzerinden yürüten sınıf
public class PayrollExcelWorkflow
{
    private string FilePath { get; }

    public PayrollExcelWorkflow(string path)
    {   
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentNullException(nameof(path));
        }
        FilePath = path;

    }


    // Bordro işlemlerini çalıştıran metot
    public void Run()
    {
        var EmloyeesList = ImportEmployees();

        PayrollCalculator calculator = new PayrollCalculator();
        List<MonthlyPayroll> allPayrolls = new List<MonthlyPayroll>();

        for(int i = 0; i < EmloyeesList.Count; i++)
        {
            var payrolls = calculator.CalculateAnnualPayrollFromGross(EmloyeesList[i]);
            allPayrolls.AddRange(payrolls);
        }

        ExportPayrolls(allPayrolls);
    }

    // Çalışanları Excel dosyasından içe aktaran metot
    private List<Employee> ImportEmployees()
    {
        EmployeeExcelImporter importer = new EmployeeExcelImporter();
        var employees = importer.ExcelImporter(FilePath);

        return employees;
    }

    // Bordro sonuçlarını Excel dosyasına aktaran metot
    private void ExportPayrolls(List<MonthlyPayroll> payrolls)
    {   
        PayrollResultExcelExporter exporter = new PayrollResultExcelExporter();
        exporter.ExportToExcel(payrolls);

    }

}
