#region Using directives

using System.Collections.Generic;
using System.Linq;
using CPETime.Data.EntityFramework.Model;

#endregion

namespace CPETime.Data.EntityFramework.Queries
{
    public class GetAllEmployeesQuery
    {
        public IList<Employee> ExecuteQuery()
        {
            using (var model = new CPETimeModelContainer()) {
                return model.Employees.ToList();
            }
        }
    }
}