namespace E_Coach
{
    using System.Collections.Generic;
    
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
            return context.Find(element);
        }

        public void Insert(IPersistence element)
        {
            context.Insert(element);
        }

        public void Delete(IPersistence element)
        {
            context.Delete(element);
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
