namespace DataModel.Models
{
    public class ScheduleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        
        public int ProjectId { get; set; }
        public ProjectModel Project { get; set; }
        
        public int UserId { get; set; }
        public UserModel User { get; set; }
        
        public int EventId { get; set; }
        public EventModel Event { get; set; }
    }
}