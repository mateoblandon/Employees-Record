using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace EmployeesRecordUI
{
  public class DataAccess
  {
    public List<Employee> GetEmployees(string firstNameOrLastName)
    {
      using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionStringHelper.ConnectionStringValue("EmployeesDBConnection")))
      {
        if(string.IsNullOrEmpty(firstNameOrLastName) || string.IsNullOrWhiteSpace(firstNameOrLastName))
        {
          var output = connection.Query<Employee>("[dbo].[GetAllEmployees]").ToList();
          return output;
        }
        else
        {
          var output = connection.Query<Employee>("[dbo].[SearchEmployee] @FirstNameOrLastName", new { FirstNameOrLastName = firstNameOrLastName }).ToList();
          return output;
        }        
      }
    }
    public void InsertEmployee(string firstName, string lastName, string area, string jobTitle, string emailAddress, string phoneNumber)
    {
      using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionStringHelper.ConnectionStringValue("EmployeesDBConnection")))
      {
        
        if(string.IsNullOrEmpty(firstName) || string.IsNullOrWhiteSpace(firstName)  || string.IsNullOrEmpty(lastName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrEmpty(area) || string.IsNullOrWhiteSpace(area) || string.IsNullOrEmpty(jobTitle) || string.IsNullOrWhiteSpace(jobTitle) || string.IsNullOrEmpty(emailAddress) || string.IsNullOrWhiteSpace(emailAddress) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrWhiteSpace(phoneNumber))
        {
          MessageBox.Show("Todos los campos son obligatorios");
        }
        else
        {
          Employee newEmployee = new Employee { FirstName = firstName, LastName = lastName, Area = area, JobTitle = jobTitle, EmailAddress = emailAddress, PhoneNumber = phoneNumber };
          connection.Execute("[dbo].[InsertEmployee] @FirstName, @LastName, @Area, @JobTitle, @EmailAddress, @PhoneNumber", newEmployee);
          MessageBox.Show("Nuevo empleado registrado");
        }
      }
    }
  }
}
