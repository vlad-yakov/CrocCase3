using System;
using DataModel;
using DataModel.Models;
using Services.Models;

namespace Services.UseCases.AddElem
{
    public class AddSchedule
    {
      public SuccessMessage TryExecute(ScheduleModel schedule)
        {
            using (DataContext db = new DataContext())
            {
                try
                {
                    db.Schedule.Add(schedule);
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