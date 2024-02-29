using Microsoft.EntityFrameworkCore;

namespace Simple.Data
{
    // This is the subclass of SimpleDbContext that will be used in the app.  We can properly set up the db connection and lazy loading here
    // so that we don't have to edit the scaffolded SimpleDbContext after every change to the db
    public class UserLogsDbContext : SimpleDbContext
    {
        public UserLogsDbContext()
        {
        }

        public UserLogsDbContext(DbContextOptions<SimpleDbContext> options)
            : base(options)
        {
        }

        // Override the scaffolded OnConfiguring which does not properly set up the db connection or lazy loading when 
        // using LINQPad
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=AppConnection");
            }
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
