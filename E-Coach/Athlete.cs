namespace E_Coach
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    [Table("Athlete")]
    public class Athlete
    {
        [Key, ReadOnly(true)]
        public int Id { get; set; }

        [EmailAddress, Required]
        public string Email { get; set; }

        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public virtual Coach Coach { internal get; set; }
        
        public virtual List<Activity> Activities { get; set; }

        public IEnumerable<Activity> GetActivities()
        {
            if (Activities != null)
            {
                foreach (var activity in Activities)
                {
                    yield return activity;
                }
            }
        }

        public void AddActivity(Activity activity)
        {
            if (Activities == null)
            {
                Activities = new List<Activity>();
            }

            Activities.Add(activity);
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var p = obj as Athlete;
            if (p == null)
            {
                return false;
            }

            return (Email == p.Email) && (Name == p.Name);
        }
    }
}
