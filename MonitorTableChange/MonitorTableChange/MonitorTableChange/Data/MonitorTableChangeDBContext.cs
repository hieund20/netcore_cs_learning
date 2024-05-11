using Microsoft.EntityFrameworkCore;
using MonitorTableChange.Models;

namespace MonitorTableChange.Data
{
    public class MonitorTableChangeDBContext : DbContext
    {
        #region Ctor
        public MonitorTableChangeDBContext(DbContextOptions<MonitorTableChangeDBContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        #endregion

        #region Fields
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MonitorEvent> MonitorEvents { get; set; }
        #endregion
    }
}
