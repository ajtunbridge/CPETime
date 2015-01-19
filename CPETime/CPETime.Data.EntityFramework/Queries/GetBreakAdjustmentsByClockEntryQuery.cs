#region Using directives

using System.Collections.Generic;
using System.Linq;
using CPETime.Data.EntityFramework.Model;

#endregion

namespace CPETime.Data.EntityFramework.Queries
{
    public class GetBreakAdjustmentsByClockEntryQuery
    {
        private readonly ClockEntry _clockEntry;

        public GetBreakAdjustmentsByClockEntryQuery(ClockEntry clockEntry)
        {
            _clockEntry = clockEntry;
        }

        public IList<BreakAdjustment> ExecuteQuery()
        {
            using (var model = new CPETimeEntities()) {
                return model.BreakAdjustments.Where(b => b.ClockEntryId == _clockEntry.Id).ToList();
            }
        }
    }
}