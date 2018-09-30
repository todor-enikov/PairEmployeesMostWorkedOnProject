using System;
using System.Collections.Generic;
using System.Text;

namespace PairEmployeesMostWorkedOnProject.Core.Business
{
    public class MostWorkedEmployeesResult
    {
        private int firstEmployeeId;

        private int secondEmployeeId;

        private int projectId;

        private double daysWorked;

        public MostWorkedEmployeesResult(int firstEmployeeId, int secondEmployeeId, int projectId, double daysWorked)
        {
            this.FirstEmployeeId = firstEmployeeId;
            this.SecondEmployeeId = secondEmployeeId;
            this.ProjectId = projectId;
            this.DaysWorked = daysWorked;
        }

        public int FirstEmployeeId
        {
            get { return this.firstEmployeeId; }
            set { this.firstEmployeeId = value; }
        }

        public int SecondEmployeeId
        {
            get { return this.secondEmployeeId; }
            set { this.secondEmployeeId = value; }
        }

        public int ProjectId
        {
            get { return this.projectId; }
            set { this.projectId = value; }
        }

        public double DaysWorked
        {
            get { return this.daysWorked; }
            set { this.daysWorked = value; }
        }
    }
}
