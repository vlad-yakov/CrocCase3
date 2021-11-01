using System;
using System.Collections.Generic;

namespace DataModel.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime HoursPerDay { get; set; }
        public int DaysPerWeek { get; set; }
        
        public List<ScheduleModel> Schedules { get; set; }
    }
}