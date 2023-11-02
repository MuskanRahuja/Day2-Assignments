using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string ReportingManager { get; set; }
    }

    class ContractEmployee : Employee
    {
        public DateTime ContractDate { get; set; }
        public int Duration { get; set; }
        public double Charges { get; set; }
    }

    class PayrollEmployee : Employee
    {
        public DateTime JoiningDate { get; set; }
        public int ExperienceYears { get; set; }
        public double BasicSalary { get; set; }
        public double DA { get; set; }
        public double HRA { get; set; }
        public double PF { get; set; }
        public double NetSalary { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>();


            ContractEmployee contractEmployee1 = new ContractEmployee
            {
                EmployeeId = 1,
                Name = "Contract Employee 1",
                ReportingManager = "Manager A",
                ContractDate = DateTime.Now,
                Duration = 6,
                Charges = 25000
            };
            employees.Add(contractEmployee1);


            PayrollEmployee payrollEmployee1 = new PayrollEmployee
            {
                EmployeeId = 2,
                Name = "Payroll Employee 1",
                ReportingManager = "Manager B",
                JoiningDate = DateTime.Now,
                ExperienceYears = 8,
                BasicSalary = 60000
            };
            CalculateNetSalary(payrollEmployee1);
            employees.Add(payrollEmployee1);


            Console.WriteLine("Employee Details:");
            foreach (Employee employee in employees)
            {
                if (employee is ContractEmployee contractEmp)
                {
                    Console.WriteLine($"Contract Employee - ID: {contractEmp.EmployeeId}, Name: {contractEmp.Name}, " +
                        $"Reporting Manager: {contractEmp.ReportingManager}, Contract Date: {contractEmp.ContractDate}, " +
                        $"Duration: {contractEmp.Duration} months, Charges: {contractEmp.Charges}");
                }
                else if (employee is PayrollEmployee payrollEmp)
                {
                    Console.WriteLine($"Payroll Employee - ID: {payrollEmp.EmployeeId}, Name: {payrollEmp.Name}, " +
                        $"Reporting Manager: {payrollEmp.ReportingManager}, Joining Date: {payrollEmp.JoiningDate}, " +
                        $"Experience: {payrollEmp.ExperienceYears} years, Basic Salary: {payrollEmp.BasicSalary:C}, " +
                        $"DA: {payrollEmp.DA:C}, HRA: {payrollEmp.HRA:C}, PF: {payrollEmp.PF:C}, " +
                        $"Net Salary: {payrollEmp.NetSalary:C}");
                }
            }


            Console.WriteLine($"Total Number of Employees: {employees.Count}");
        }

        static void CalculateNetSalary(PayrollEmployee employee)
        {
            if (employee.ExperienceYears > 10)
            {
                employee.DA = 0.10 * employee.BasicSalary;
                employee.HRA = 0.085 * employee.BasicSalary;
                employee.PF = 6200;
            }
            else if (employee.ExperienceYears > 7)
            {
                employee.DA = 0.07 * employee.BasicSalary;
                employee.HRA = 0.065 * employee.BasicSalary;
                employee.PF = 4100;
            }
            else if (employee.ExperienceYears > 5)
            {
                employee.DA = 0.041 * employee.BasicSalary;
                employee.HRA = 0.038 * employee.BasicSalary;
                employee.PF = 1800;
            }
            else
            {
                employee.DA = 0.019 * employee.BasicSalary;
                employee.HRA = 0.02 * employee.BasicSalary;
                employee.PF = 1200;
            }

            employee.NetSalary = employee.BasicSalary + employee.DA + employee.HRA - employee.PF;
        }
    }


}

