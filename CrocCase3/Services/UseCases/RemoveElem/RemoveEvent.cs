using System;
using DataModel;
using Services.Models;

namespace Services.UseCases.RemoveElem
{
    public class RemoveEvent
    {
        public SuccessMessage TryExecute(int eventId)
        {
            using (DataContext db = new DataContext())
            {
                try
                {
                    var eventElem = db.Events.Find(eventId);
                    db.Events.Remove(eventElem);
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