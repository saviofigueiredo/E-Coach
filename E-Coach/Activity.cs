namespace E_Coach
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(TableName)]
    public class Activity : IPersistence
    {
        internal const string TableName = "Activity";

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public virtual Athlete Athlete { internal get; set; }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var p = obj as Activity;
            if (p == null)
            {
                return false;
            }

            return (Description == p.Description) && (Date.ToShortDateString() == p.Date.ToShortDateString());
        }

        internal override string GetTableName()
        {
            return TableName;
        }
    }
}
