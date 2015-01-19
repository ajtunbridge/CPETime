#region Using directives

using System.Linq;
using CPETime.Data.EntityFramework.Model;

#endregion

namespace CPETime.Data.EntityFramework.Queries
{
    public class GetEmployeeByIdQuery
    {
        private readonly int _employeeId;

        public GetEmployeeByIdQuery(int employeeId)
        {
            _employeeId = employeeId;
        }

        public Employee ExecuteQuery()
        {
            using (var model = new CPETimeEntities()) {
                return model.Employees.SingleOrDefault(e => e.Id == _employeeId);
            }
        }
    }
}