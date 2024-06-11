using Microsoft.EntityFrameworkCore;
using school_manager.Models;

namespace school_manager.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
            
        }
        public DbSet<AcademicYear> AcademicYear => Set<AcademicYear>();
    }
}
