namespace AkvelonTestTask.Common
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? CompletionDate { get; set; }
        public ProjectStatus? Status { get; set; }
        public int? Priority { get; set; }
    }
}