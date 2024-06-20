using Microsoft.EntityFrameworkCore;
using school_manager.Models;

namespace school_manager.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
            
        }
        public DbSet<AcademicYear> AcademicYear => Set<AcademicYear>();
        public DbSet<Class> Class => Set<Class>();
        public DbSet<Subject> Subject => Set<Subject>();
        public DbSet<Teacher> Teacher => Set<Teacher>();
        public DbSet<Student> Student => Set<Student>();
        public DbSet<Grade> Grade => Set<Grade>();
    }
}
