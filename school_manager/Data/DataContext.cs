using Microsoft.EntityFrameworkCore;

namespace school_manager.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
