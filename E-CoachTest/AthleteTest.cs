using System.Linq;

namespace E_CoachTest
{
    using E_Coach;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AthleteTest
    {
        [TestMethod]
        public void AthleteActivitiesAreCorrectlySaved()
        {
            var newCoach = new Coach { Email = "coach@email.com", Name = "Joel Santana" };
            var newAthlete = new Athlete() { Email = "zico@flamengo.com.br", Name = "Zico" };
            var newActivity = new Activity() { Date = System.DateTime.Now, Description = "Run 5 kms" };
            newAthlete.AddActivity(newActivity);
            newCoach.AddAthlete(newAthlete);

            newCoach.Insert();

            PersistenceManager.Get().Find(newAthlete).GetActivities().FirstOrDefault().ShouldBeEquivalentTo(newActivity);
        }

        [TestInitialize]
        public void TestSetup()
        {
            using (var dbContext = new ContextHelper())
            {
                foreach (var coach in dbContext.Coaches)
                {
                    dbContext.Coaches.Remove(coach);
                }

                dbContext.SaveChanges();
            }
        }

    }
}
