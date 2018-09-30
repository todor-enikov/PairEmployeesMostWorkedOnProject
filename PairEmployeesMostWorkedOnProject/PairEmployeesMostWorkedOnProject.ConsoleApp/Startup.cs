using PairEmployeesMostWorkedOnProject.Core;
using System;

namespace PairEmployeesMostWorkedOnProject.ConsoleApp
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var pathtoFile = @"C:\Users\ASUS K53SM\Desktop\Employees.txt";
            var manager = new EmployeeManager(pathtoFile);

            manager.CalculateMostWorkedEmployeesOnProject();

        }
    }
}
