using PairEmployeesMostWorkedOnProject.Core.Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PairEmployeesMostWorkedOnProject.Core
{
    public class EmployeeManager
    {
        private string[] linesFromFile;

        public EmployeeManager(string pathToFile)
        {
            this.linesFromFile = File.ReadAllLines(pathToFile);
        }

        public List<MostWorkedEmployeesUnit> CalculateMostWorkedEmployeesInProject()
        {
            Dictionary<int, List<Employee>> structure = GenerateStructureForCalculation();
            var mostWorkedEmployeesResult = new List<MostWorkedEmployeesUnit>();

            foreach (var item in structure)
            {
                List<Employee> currentEmployees = item.Value;
                MostWorkedEmployeesUnit currentMostWorkedEmployeesUnit = CalculateCurrentMostWorkedEmployeesUnit(currentEmployees, item.Key);
                if (currentMostWorkedEmployeesUnit.DaysWorked != -1)
                {
                    mostWorkedEmployeesResult.Add(currentMostWorkedEmployeesUnit);
                }
            }

            return mostWorkedEmployeesResult.OrderByDescending(x => x.DaysWorked).ToList();
        }

        private Dictionary<int, List<Employee>> GenerateStructureForCalculation()
        {
            var lines = this.linesFromFile;
            string[] stringSeparators = new string[] { ", " };
            var structure = new Dictionary<int, List<Employee>>();

            foreach (var line in lines)
            {
                var currentLine = line.Replace("NULL", DateTime.Now.ToString());
                string[] currentLineSplit = currentLine.Split(stringSeparators, StringSplitOptions.None);

                int currentProjectId = int.Parse(currentLineSplit[0]);
                int currentEmployeeId = int.Parse(currentLineSplit[1]);
                DateTime currentDateFrom = DateTime.Parse(currentLineSplit[2]);
                DateTime currentDateTo = DateTime.Parse(currentLineSplit[3]);

                var currentEmployee = new Employee(currentEmployeeId, currentDateFrom, currentDateTo);
                if (structure.ContainsKey(currentProjectId))
                {
                    structure[currentProjectId].Add(currentEmployee);
                }
                else
                {
                    structure.Add(currentProjectId, new List<Employee>() { currentEmployee });
                }
            }

            return structure.Where(x => x.Value.Count > 1).ToDictionary(x => x.Key, x => x.Value);
        }

        private MostWorkedEmployeesUnit CalculateCurrentMostWorkedEmployeesUnit(List<Employee> currentEmployees, int projectId)
        {
            var currentMostWorkedEmployeesUnit = new MostWorkedEmployeesUnit(-1, -1, -1, -1);

            for (int i = 0; i < currentEmployees.Count; i++)
            {
                var currentEmployee = currentEmployees[i];
                var currentEmployeeId = currentEmployee.EmployeeId;
                var currentEmployeeDateFrom = currentEmployee.DateFrom;
                var currentEmployeeDateTo = currentEmployee.DateTo;

                for (int j = i + 1; j < currentEmployees.Count; j++)
                {
                    var nextEmployee = currentEmployees[j];
                    var nextEmployeeId = nextEmployee.EmployeeId;
                    var nextEmployeeDateFrom = nextEmployee.DateFrom;
                    var nextEmployeeDateTo = nextEmployee.DateTo;

                    DateTime currentDateFromWorkedTogether = DateTime.Now;
                    if (currentEmployeeDateFrom >= nextEmployeeDateFrom)
                    {
                        currentDateFromWorkedTogether = currentEmployeeDateFrom;
                    }
                    else
                    {
                        currentDateFromWorkedTogether = nextEmployeeDateFrom;
                    }

                    DateTime currentDateToWorkedTogether = DateTime.Now;
                    if (currentEmployeeDateTo >= nextEmployeeDateTo)
                    {
                        currentDateToWorkedTogether = currentEmployeeDateTo;
                    }
                    else
                    {
                        currentDateToWorkedTogether = nextEmployeeDateTo;
                    }

                    var daysWorkedTogether = (currentDateToWorkedTogether - currentDateFromWorkedTogether).TotalDays;

                    if (currentMostWorkedEmployeesUnit.DaysWorked < daysWorkedTogether)
                    {
                        currentMostWorkedEmployeesUnit = new MostWorkedEmployeesUnit(currentEmployeeId, nextEmployeeId, projectId, Math.Ceiling(daysWorkedTogether));
                    }
                }
            }

            return currentMostWorkedEmployeesUnit;
        }
    }
}
