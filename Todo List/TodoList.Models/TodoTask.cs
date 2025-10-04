using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class TodoTask
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        public string Title { get; set; } = string.Empty;
        
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string Description { get; set; } = string.Empty;
        
        [StringLength(50, ErrorMessage = "Category cannot exceed 50 characters")]
        public string Category { get; set; } = "General";
        
        public DateTime? DueDate { get; set; }
        
        public TaskStatus Status { get; set; } = TaskStatus.Pending;
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime? ModifiedDate { get; set; }
        
        public bool IsCompleted => Status == TaskStatus.Done;
        
        public bool IsOverdue => DueDate.HasValue && DueDate.Value < DateTime.Now && !IsCompleted;
    }
}
