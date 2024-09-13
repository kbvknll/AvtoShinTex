using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AvtoShinTex.Data;

namespace AvtoShinTex
{
    public partial class MainWindow : Window
    {
        private List<EmployeeInfo> _employeeInfos;
        private List<CommissionData> _commissionDataList;

        public MainWindow()
        {
            InitializeComponent();
            _employeeInfos = Data.DataContext.EmployeeInfos.ToList();
            EmployeeComboBox.ItemsSource = _employeeInfos;
            _commissionDataList = new List<CommissionData>();
        }

        private void EmployeeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeeComboBox.SelectedItem is EmployeeInfo selectedEmployee)
            {
                HireDatePicker.SelectedDate = DateTime.Parse(selectedEmployee.Date);
            }
        }

        private double CalculateCommission(EmployeeInfo employee, double dailyRevenue)
        {
            double commissionRate = dailyRevenue < 50000 ? 0.03 : 0.06;
            double commission = dailyRevenue * commissionRate;

            DateTime hireDate = DateTime.Parse(employee.Date);
            if ((DateTime.Now - hireDate).TotalDays / 365.25 > 3)
            {
                commission += dailyRevenue * 0.05;
            }

            return commission;
        }

        private void CalculateCommission_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeComboBox.SelectedItem is EmployeeInfo selectedEmployee && HireDatePicker.SelectedDate.HasValue && double.TryParse(DailyRevenueTextBox.Text, out double dailyRevenue))
            {
                double commission = CalculateCommission(selectedEmployee, dailyRevenue);
                int yearsOfService = (int)((DateTime.Now - DateTime.Parse(selectedEmployee.Date)).TotalDays / 365.25);

                var commissionData = new CommissionData
                {
                    Name = selectedEmployee.Name,
                    Commission = commission,
                    DailyRevenue = dailyRevenue,
                    YearsOfService = yearsOfService
                };

                _commissionDataList.Add(commissionData);
                CommissionDataGrid.ItemsSource = null;
                CommissionDataGrid.ItemsSource = _commissionDataList;
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля корректно.");
            }
        }
    }

    public class CommissionData
    {
        public string Name { get; set; }
        public double Commission { get; set; }
        public double DailyRevenue { get; set; }
        public int YearsOfService { get; set; }
    }
}
