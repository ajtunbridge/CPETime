#region Using directives

using System.Linq;
using CPETime.Data.EntityFramework.Model;

#endregion

namespace CPETime.Data.EntityFramework.Commands
{
    public class AddEmployeeBreakCommand
    {
        private readonly Break _break;
        private readonly Employee _employee;

        public AddEmployeeBreakCommand(Employee employee, Break @break)
        {
            _employee = employee;
            _break = @break;
        }

        public void ExecuteCommand()
        {
            using (var model = new CPETimeModelContainer()) {
                EmployeeBreak existing =
                    model.EmployeeBreaks.SingleOrDefault(eb => eb.EmployeeId == _employee.Id && eb.BreakId == _break.Id);
                if (existing == null) {
                    var employeeBreak = new EmployeeBreak();
                    employeeBreak.EmployeeId = _employee.Id;
                    employeeBreak.BreakId = _break.Id;
                    model.EmployeeBreaks.Add(employeeBreak);
                    model.SaveChanges();
                }
            }
        }
    }
}