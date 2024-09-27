using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff:Passenger
    {
        public string Function { get; set; }

        [DataType(DataType.Currency)]
        public double Salary { get; set; }
        public DateTime EmploymentDate { get; set; }
        public override string ToString()
        {
            return base.ToString()+ " Le salaire= "+ Salary;
        }
    }
}
