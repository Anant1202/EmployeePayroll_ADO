using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollService
{
    public class Emp_Payroll
    {
        public int emp_id { get; set; }
        public string empname { get; set; }
        public double salary { get; set; }
        public DateTime start_date { get; set; }
        public char gender { get; set; }
        public long phonenumber { get; set; }
        public string department { get; set; }
        public string address { get; set; }
        public double Deduction { get; set; }
        public double IncomeTax { get; set; }
        public double TaxablePay { get; set; }
        public double NetPay { get; set; }
    }
}
