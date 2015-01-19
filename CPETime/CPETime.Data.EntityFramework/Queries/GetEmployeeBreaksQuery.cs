#region Using directives

using System.Collections.Generic;
using System.Linq;
using CPETime.Data.EntityFramework.Model;

#endregion

namespace CPETime.Data.EntityFramework.Queries
{
    public class GetEmployeeBreaksQuery
    {
        private readonly Employee _employee;

        public GetEmployeeBreaksQuery(Employee employee)
        {
            _employee = employee;
        }

        public IList<Break> ExecuteQuery()
        {
            using (var model = new CPETimeEntities()) {
                return model.EmployeeBreaks.Where(eb => eb.EmployeeId == _employee.Id)
                    .Select(eb => eb.Break)
                    .ToList();
            }
        }
    }
}