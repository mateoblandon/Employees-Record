using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeesRecordUI
{
  public partial class SearchAndInsertForm : Form
  {
    List<Employee> employees = new List<Employee>();
    public SearchAndInsertForm()
    {
      InitializeComponent();
      UpdateBinding();
    }
    private void UpdateBinding()
    {
      employeesFoundListBox.DataSource = employees;
      employeesFoundListBox.DisplayMember = "FullInfo";
    }
    private void searchButton_Click(object sender, EventArgs e)
    {
      DataAccess dataAccess = new DataAccess();
      employees = dataAccess.GetEmployees(searchNameTextBox.Text);
      UpdateBinding();
    }

    private void InsertButton_Click(object sender, EventArgs e)
    {
      DataAccess dataAccess = new DataAccess();
      dataAccess.InsertEmployee(firstNameInsertTextBox.Text, lastNameInsertTextBox.Text, areaInsertTextBox.Text, jobTitleInsertTextBox.Text, emailAddressInsertTextBox.Text, phoneNumbertInsertTextBox.Text);
      firstNameInsertTextBox.Text = "";
      lastNameInsertTextBox.Text = "";
      areaInsertTextBox.Text = "";
      jobTitleInsertTextBox.Text = "";
      emailAddressInsertTextBox.Text = "";
      phoneNumbertInsertTextBox.Text = "";
    }
  }
}
