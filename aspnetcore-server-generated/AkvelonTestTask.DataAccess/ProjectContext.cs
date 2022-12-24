using AkvelonTestTask.Common;
using Microsoft.EntityFrameworkCore;

namespace AkvelonTestTask.DataAccess
{
    public class ProjectContext : DbContext
    {
        private const string ConnectionString = "Server=localhost\\SQLEXPRESS;Database=Akvelon_TestTask;Trusted_Connection=True;TrustServerCertificate=True;";
        public DbSet<Project> Projects { get; set; }
        public DbSet<Common.Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(ConnectionString);
    }
}