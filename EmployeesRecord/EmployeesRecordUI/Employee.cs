using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesRecordUI
{
  public class Employee
  {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Area { get; set; }
        public string JobTitle { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string FullInfo 
        {
          get { return $"{FirstName} {LastName}: {Area} - {JobTitle} - {EmailAddress}"; }
        }  
    }
}
