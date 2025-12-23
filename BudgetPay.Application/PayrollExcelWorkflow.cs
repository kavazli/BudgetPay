using System;
using BudgetPay.Domain;
using BudgetPay.

namespace BudgetPay.Application;


public class PayrollExcelWorkflow
{
    private string Path { get; }

    public PayrollExcelWorkflow(string path)
    {
        Path = path;
    }


    private List<Employee> ImportEmployees()
    {
        EmployeeExcelImporter importer = new EmployeeExcelImporter();

        return
    }


}
