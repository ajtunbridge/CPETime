#region Using directives

using System;
using CPETime.Data.EntityFramework.Model;

#endregion

namespace CPETime.Data.EntityFramework.Commands
{
    public class AddBreakCommand
    {
        private readonly Break _breakToAdd;

        public AddBreakCommand(string description, TimeSpan startTime, TimeSpan endTime)
        {
            _breakToAdd = new Break {
                Description = description,
                StartTime = startTime,
                EndTime = endTime
            };
        }

        public void ExecuteCommand()
        {
            using (var model = new CPETimeModelContainer()) {
                model.Breaks.Add(_breakToAdd);
                model.SaveChanges();
            }
        }
    }
}