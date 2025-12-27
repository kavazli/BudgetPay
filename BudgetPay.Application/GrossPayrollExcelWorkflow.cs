using System;
using BudgetPay.Domain;
using BudgetPay.Infrastructure;

namespace BudgetPay.Application;

public class GrossPayrollExcelWorkflow
{
    private string FilePath { get; }

    public GrossPayrollExcelWorkflow(string path)
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

        GrossToNetPayrollCalculator calculator = new GrossToNetPayrollCalculator();
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
