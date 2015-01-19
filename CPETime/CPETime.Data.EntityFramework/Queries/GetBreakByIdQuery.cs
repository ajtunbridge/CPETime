#region Using directives

using System.Linq;
using CPETime.Data.EntityFramework.Model;

#endregion

namespace CPETime.Data.EntityFramework.Queries
{
    public class GetBreakByIdQuery
    {
        private readonly int _breakId;

        public GetBreakByIdQuery(int breakBreakId)
        {
            _breakId = breakBreakId;
        }

        public Break ExecuteQuery()
        {
            using (var model = new CPETimeEntities()) {
                return model.Breaks.SingleOrDefault(b => b.Id == _breakId);
            }
        }
    }
}