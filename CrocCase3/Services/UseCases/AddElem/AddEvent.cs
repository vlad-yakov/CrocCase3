namespace Services.UseCases.AddElem
{
    using System;
    using DataModel;
    using DataModel.Models;
    using Models;

    public class AddEvent
    {
        public SuccessMessage TryExecute(EventModel eventElem)
        {
            using (DataContext db = new DataContext())
            {
                try
                {
                    db.Events.Add(eventElem);
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