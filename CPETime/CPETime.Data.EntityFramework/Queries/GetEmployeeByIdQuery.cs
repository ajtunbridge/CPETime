using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPETime.Data.EntityFramework.Model;

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
            using (var model = new CPETimeModelContainer()) {
                return model.Employees.SingleOrDefault(e => e.Id == _employeeId);
            }
        }
    }
}
