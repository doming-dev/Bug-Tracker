namespace BugTracker.Models
{
    public class UserWorkItem
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int WorkItemId { get; set; }
        public WorkItem WorkItem { get; set; }
    }
}
