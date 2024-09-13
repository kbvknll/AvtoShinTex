using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtoShinTex.Data
{
    public class EmployeeInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }

        public EmployeeInfo(int id, string name, string date)
        {
            Id = id;
            Name = name;
            Date = date;
        }
    }
}
