using System;
using DataModel;
using Services.Models;

namespace Services.UseCases.RemoveElem
{
    public class RemoveSchedule
    {
        public SuccessMessage TryExecute(int scheduleId)
        {
            using (DataContext db = new DataContext())
            {
                try
                {
                    var schedule = db.Schedule.Find(scheduleId);
                    db.Schedule.Remove(schedule);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ////todo
                }
            }
            
            var result = new SuccessMessage
            {
                Success = true
            };

            return result;
        }
    }
}