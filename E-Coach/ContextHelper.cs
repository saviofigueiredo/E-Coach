namespace E_Coach
{
    using System.Data.Entity;
    
    public class ContextHelper : DbContext
    {
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Activity> Activities { get; set; }

        internal T Find<T>(T element) where T : IPersistence
        {
            return GetDbSet(element).Find(element.Id) as T;
        }

        internal void Insert(IPersistence element)
        {
            GetDbSet(element).Add(element);
            SaveChanges();
        }

        internal void Delete(IPersistence element)
        {
            GetDbSet(element).Remove(element);
            SaveChanges();
        }

        private DbSet GetDbSet(IPersistence element)
        {
            if (element is Activity)
            {
                return Activities;
            }

            if (element is Athlete)
            {
                return Athletes;
            }

            if (element is Coach)
            {
                return Coaches;
            }

            return null;
        }
    }
}
