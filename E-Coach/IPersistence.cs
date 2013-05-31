namespace E_Coach
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public abstract class IPersistence
    {
        [Key, ReadOnly(true)]
        public int Id { get; set; }        
        
        internal abstract string GetTableName();

        public void Insert()
        {
            PersistenceManager.Get().Insert(this);
        }
    
        public void Delete()
        {
            PersistenceManager.Get().Delete(this);
        }
    }
}
