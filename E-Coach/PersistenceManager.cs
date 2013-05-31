namespace E_Coach
{
    using System.Collections.Generic;
    using System.Data.Entity;
    
    public class PersistenceManager
    {
        private ContextHelper context;
        private static PersistenceManager persistenceManager;
        
        private PersistenceManager()
        {
            context = new ContextHelper();        
        }

        public static PersistenceManager Get()
        {
            return persistenceManager ?? (persistenceManager = new PersistenceManager());
        }
        
        internal static void Dispose()
        {
            if (persistenceManager != null)
            {
                persistenceManager.DisposeContext();
                persistenceManager = null;
            }
        }

        public IEnumerable<Coach> Coaches()
        {
            return context.Coaches;
        }

        public T Find<T>(T element) where T : IPersistence 
        {
             return GetDbSet(element).Find(element.Id) as T;
        }

        public void Insert(IPersistence element)
        {
            GetDbSet(element).Add(element);
            context.SaveChanges();
        }

        public void Delete(IPersistence element)
        {
            var dbSet = GetDbSet(element);
            dbSet.Remove(element);
            context.SaveChanges();
        }

        private DbSet GetDbSet(IPersistence element)
        {
            if (element is Activity)
            {
                return context.Activities;
            }
            
            if (element is Athlete)
            {
                return context.Athletes;
            }
        
            if (element is Coach)
            {
                return context.Coaches;
            }

            return null;
        }

        private void DisposeContext()
        {
            if (context != null)
            {
                context.Dispose();
                context = null;
            }
        }
    }
}
