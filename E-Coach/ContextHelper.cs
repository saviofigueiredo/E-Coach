namespace E_Coach
{
    using System.Data.Entity;
    
    public class ContextHelper : DbContext
    {
        public ContextHelper()
        : base(@"data source=localhost; 
                 initial catalog=ECOACH;
                 integrated security=true;")
        {
        }

        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Activity> Activities { get; set; }
    }
}
