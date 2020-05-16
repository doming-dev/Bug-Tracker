using BugTracker.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class WorkItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [Required]
        public WorkItemStatus Status { get; set; }
        [Required]
        public WorkItemType Type { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        //public List<UserWorkItem> Users { get; set; }
    }
}
