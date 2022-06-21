using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMultiThreading
{
    public class EmployeePayrollOperation
    {
        public List<EmployeeDetails> employeeDatalist = new List<EmployeeDetails>();
        public void AddEmployee(List<EmployeeDetails> employeeDatalist)
        {
            employeeDatalist.ForEach(employeeData =>
            {
                Console.WriteLine("Employee being added: " + employeeData.Name);
                this.AddEmployeePayroll(employeeData);
                Console.WriteLine("Employee added: " + employeeData.Name);
            }
            );
            Console.WriteLine(this.employeeDatalist.ToString());
        }
        public void AddEmployeePayrollThread(List<EmployeeDetails> employeeDatalist)
        {
            employeeDatalist.ForEach(employeeData =>

            {
                Task thread = new Task(() =>
                {
                    Console.WriteLine("Employee being added: " + employeeData.Name);
                    this.AddEmployeePayroll(employeeData);
                    Console.WriteLine("Employee added: " + employeeData.Name);

                });
                thread.Start();
            });
            Console.WriteLine(this.employeeDatalist.Count);
        }
        public void AddEmployeePayroll(EmployeeDetails employee)
        {
            employeeDatalist.Add(employee);
        }
    }
}
