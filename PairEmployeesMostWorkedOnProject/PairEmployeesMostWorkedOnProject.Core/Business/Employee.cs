using System;
using System.Collections.Generic;
using System.Text;

namespace PairEmployeesMostWorkedOnProject.Core.Business
{
    public class Employee
    {
        private int employeeId;

        private DateTime dateFrom;

        private DateTime dateTo;

        public Employee(int employeeId, DateTime dateFrom, DateTime dateTo)
        {
            this.EmployeeId = employeeId;
            this.DateFrom = dateFrom;
            this.DateTo = dateTo;
        }

        public int EmployeeId
        {
            get { return this.employeeId; }
            set { this.employeeId = value; }
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
