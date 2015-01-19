#region Using directives

using System;
using CPETime.Data.EntityFramework.Model;

#endregion

namespace CPETime.Data.EntityFramework.Commands
{
    public class AddEmployeeCommand
    {
        private readonly Employee _employeeToAdd;

        public AddEmployeeCommand(string firstName, string middleName, string lastName, DateTime dateOfBirth)
        {
            _employeeToAdd = new Employee {
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                DateOfBirth = dateOfBirth
            };
        }

        public void ExecuteCommand()
        {
            using (var model = new CPETimeModelContainer()) {
                model.Employees.Add(_employeeToAdd);
                model.SaveChanges();
            }
        }
    }
}