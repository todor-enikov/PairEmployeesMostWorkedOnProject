using System;
using System.Collections.Generic;
using System.Text;

namespace PairEmployeesMostWorkedOnProject.Core.Business
{
    public class Employee
    {
        private int employeeID;

        private DateTime dateFrom;

        private DateTime dateTo;

        public Employee(int employeeID, DateTime dateFrom, DateTime dateTo)
        {
            this.EmployeeID = employeeID;
            this.DateFrom = dateFrom;
            this.DateTo = dateTo;
        }

        public int EmployeeID
        {
            get { return this.employeeID; }
            set { this.employeeID = value; }
        }

        public DateTime DateFrom
        {
            get { return this.dateFrom; }
            set { this.dateFrom = value; }
        }

        public DateTime DateTo
        {
            get { return this.dateTo; }
            set { this.dateTo = value; }
        }
    }
}
