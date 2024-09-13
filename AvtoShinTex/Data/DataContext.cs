using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtoShinTex.Data
{
    public static class DataContext
    {
        public static List<EmployeeInfo> EmployeeInfos = new List<EmployeeInfo>
        {
            new EmployeeInfo(10153, "Чупашева А.И.", "01.10.2015"),
            new EmployeeInfo(20174, "Иванов А.В.", "10.01.2017"),
            new EmployeeInfo(30191, "Кривцов О.П.", "05.02.2019"),
            new EmployeeInfo(40140, "Янаева Э.С.", "15.12.2014")
        };
    }
}
