using System.ComponentModel.DataAnnotations.Schema;

namespace E_Coach
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    [Table("Coach")]
    public class Coach
    {
        [Key, ReadOnly(true)]
        public int Id { get; set; }

        [EmailAddress, Required]
        public string Email { get; set; }

        [MinLength(3)]
        public string Name { get; set; }

        public virtual List<Athlete> Athletes { get; set; }

        public IEnumerable<Athlete> GetAthletes()
        {
            if (Athletes != null)
            {
                foreach (var athlete in Athletes)
                {
                    yield return athlete;
                }
            }
        }

        public void AddAthlete(Athlete athlete)
        {
            if (Athletes == null)
            {
                Athletes = new List<Athlete>();
            }

            Athletes.Add(athlete);
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var p = obj as Coach;
            if (p == null)
            {
                return false;
            }

            return (Email == p.Email) && (Name == p.Name);
        }
    }
}
