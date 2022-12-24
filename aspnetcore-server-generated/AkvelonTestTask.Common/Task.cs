using System.ComponentModel.DataAnnotations.Schema;

namespace AkvelonTestTask.Common
{
    [Table("Tasks")]
    public class Task
    {
        [Column("TaskId")]
        public int? Id { get; set; }

        [Column("TaskName")]
        public string Name { get; set; }

        [Column("TaskStatusId", TypeName = "tinyint")]
        public TaskStatus? Status { get; set; }

        [Column("TaskDescription")]
        public string? Description { get; set; }

        [Column("TaskPriority")]
        public int? Priority { get; set; }

        [Column("ProjectId")]
        public int ProjectId { get; set; }
    }
}
