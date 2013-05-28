namespace E_Coach
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Activity
    {
        [Key]
        public int Id { get; set; }

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

    }
}
