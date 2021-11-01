using System;
using System.Collections.Generic;

namespace DataModel.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WeekDay { get; set; }
        public DateTime WorkTimeStart { get; set; }
        public DateTime WorkTimeFinish { get; set; }
        
        public List<ScheduleModel> Schedules { get; set; } 
    }
}