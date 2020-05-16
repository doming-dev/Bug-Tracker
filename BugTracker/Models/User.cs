using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public List<UserViewedWorkItem> PreviouslyViewedWorkItems { get; set; }
        public List<UserWorkItem> TrackedWorkItems { get; set; }
    }
}
