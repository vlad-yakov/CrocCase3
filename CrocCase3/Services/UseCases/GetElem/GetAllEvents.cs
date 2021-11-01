using System;
using System.Collections.Generic;
using System.Linq;
using DataModel;
using DataModel.Models;
using Services.Models;

namespace Services.UseCases.GetElem
{
    public class GetAllEvents
    {
        public IEnumerable<EventModel> TryExecute()
        {
            var result = new List<EventModel>();
            using (DataContext db = new DataContext())
            {
                try
                {
                    var eventElems = db.Events.ToList();
                    result.AddRange(eventElems);
                }
                catch (Exception e)
                {
                    ////todo
                }
            }
            
            // var result = new SuccessMessage
            // {
            //     Success = true
            // };

            return result;
        }

    }
}