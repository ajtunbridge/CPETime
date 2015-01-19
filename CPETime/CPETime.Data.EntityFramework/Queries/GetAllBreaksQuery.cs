#region Using directives

using System.Collections.Generic;
using System.Linq;
using CPETime.Data.EntityFramework.Model;

#endregion

namespace CPETime.Data.EntityFramework.Queries
{
    public class GetAllBreaksQuery
    {
        public IList<Break> ExecuteQuery()
        {
            using (var model = new CPETimeModelContainer()) {
                return model.Breaks.ToList();
            }
        }
    }
}