using System;

namespace EmployeeePayrollService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll Services Program using ADO");
            //EmployeePayrollService.Employee.CreatingDatabase();
            EmployeePayrollService.Employee.Createtable();
            //EmployeePayrollService.Employee.Insert();
            //EmployeePayrollService.Employee.Retrivingdata();
        }
    }
}