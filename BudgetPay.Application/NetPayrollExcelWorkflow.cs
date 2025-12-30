
using BudgetPay.Application.Interfaces;
using BudgetPay.Application.RetiredEmployeeCalculator;
using BudgetPay.Domain;
using BudgetPay.Infrastructure;


namespace BudgetPay.Application;

// Bordro işlemlerini Excel dosyası üzerinden yürüten sınıf
public class NetPayrollExcelWorkflow
{
    private string FilePath { get; }

    public NetPayrollExcelWorkflow(string path)
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

        

        IEmployeeCalculator RetiredCalculator = new RetiredNetToGrossPayrollCalculator();
        IEmployeeCalculator ActiveCalculator = new NetToGrossPayrollCalculator();

        List<MonthlyPayroll> allPayrolls = new List<MonthlyPayroll>();

        for(int i = 0; i < EmloyeesList.Count; i++)
        {   
            if (EmloyeesList[i].Status == "Emekli")
            {
                var allpayrolls = RetiredCalculator.CalculateAnnualPayroll(EmloyeesList[i]);
                allPayrolls.AddRange(allpayrolls);
                continue;
            }
            if ( EmloyeesList[i].Status == "Normal")
            {
                var allpayrolls = ActiveCalculator.CalculateAnnualPayroll(EmloyeesList[i]);
                allPayrolls.AddRange(allpayrolls);
                continue;
            }
            
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
