using Microsoft.EntityFrameworkCore;

namespace lab7.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> contextOption) : base(contextOption) { }
        public DbSet<Student> students { get; set; }
    }
}
