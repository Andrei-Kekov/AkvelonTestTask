using System.ComponentModel.DataAnnotations.Schema;

namespace AkvelonTestTask.Common
{
    [Table("Projects")]
    public class Project
    {
        [Column("ProjectId")]
        public int? Id { get; set; }

        [Column("ProjectName")]
        public string Name { get; set; }

        [Column("ProjectStartDate")]
        public DateTime? StartDate { get; set; }

        [Column("ProjectCompletionDate")]
        public DateTime? CompletionDate { get; set; }

        [Column("ProjectStatusId", TypeName = "tinyint")]
        public ProjectStatus? Status { get; set; }

        [Column("ProjectPriority")]
        public int? Priority { get; set; }
    }
}