using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace EmployeePayrollService
{
    public class Employee
    {
        public static void CreatingDatabase()
        {
            SqlConnection obj1 = new SqlConnection("data source=DESKTOP-MC3EMTI; initial catalog=employee; integrated security=true");
            try
            {
                // writing sql query  
                SqlCommand obj2 = new SqlCommand("create database employee", obj1);
                // Opening Connection  
                obj1.Open();
                // Executing the SQL query  
                obj2.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Database is Created  Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went Wrong." + ex);
            }
            // Closing the connection  
            finally
            {
                obj1.Close();
            }
        }
        public static SqlConnection connection = new SqlConnection("data source=DESKTOP-MC3EMTI; database=employee; integrated security=true");
        public static void Createtable()
        {
            try
            {
                // writing sql query  
                SqlCommand obj1 = new SqlCommand("create table emp_payroll(empid int identity(1,1) primary key,empname varchar(200),salary varchar(200),start_date date,gender varchar(200),phonenumber bigint,department varchar(200),address varchar(200))", connection);
                // Opening Connection  
                connection.Open();
                // Executing the SQL query  
                obj1.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Table is created  Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("something went wrong." + ex);
            }
            // Closing the connection  
            finally
            {
                connection.Close();
            }
        }
        public static void Insert()
        {

            try
            {
                // writing sql query  
                SqlCommand obj1 = new SqlCommand("insert into emp_payroll values('Sameer',30000,'2022-2-11','M',9114682095,'testing''Bangalore')", connection);
                // Opening Connection  
                connection.Open();
                // Executing the SQL query  
                obj1.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Record Inserted  Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("something went wrong." + ex);
            }
            // Closing the connection  
            finally
            {
                connection.Close();
            }
        }
        public static void Retrivingdata()
        {
            // Creating Connection  
            SqlConnection connection = new SqlConnection("data source=DESKTOP-MC3EMTI; database=employee; integrated security=true");
            try
            {
                // writing sql query  
                SqlCommand obj1 = new SqlCommand("select * from emp_payroll", connection);
                // Opening Connection  
                connection.Open();
                // Executing the SQL query  
                SqlDataReader sdr = obj1.ExecuteReader();
                // Iterating Data  
                while (sdr.Read())
                {
                    // Displaying Record  
                    Console.WriteLine(sdr["empid"] + " " + sdr["empname"] + " " + sdr["salary"] + " " + sdr["start_date"] + " " + sdr["gender"] + " " + sdr["phonenumber"] + " " + sdr["department"] + " " + sdr["address"] + " " + sdr["Deduction"] + " " + sdr["empname"]
                        + " " + sdr["IncomeTax"] + " " + sdr["TaxablePay"] + " " + sdr["NetPay"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(" something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                connection.Close();
            }
        }
        public bool UpdateSalary(Emp_Payroll empdata)
        {
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("dbo.spUpdateSalary", connection);
                    cmd.CommandType = CommandType.StoredProcedure;//excuting stored procedure
                    cmd.Parameters.AddWithValue("@salary", empdata.salary);
                    cmd.Parameters.AddWithValue("@EmpName", empdata.empname);
                    cmd.Parameters.AddWithValue("@EmpId", empdata.emp_id);

                    connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
    }
}
