using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EmployeesRecordUI
{
  public class ConnectionStringHelper
  {
    public static string ConnectionStringValue(string connectionStringName)
    {
      return ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
    }
  }
}
