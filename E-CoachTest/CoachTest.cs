using FluentAssertions;

namespace E_CoachTest
{
    using E_Coach;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CoachTest
    {
        [TestMethod]
        public void CoachIsCorrectlySaved()
        {
            var newCoach = new Coach {Email = "coach@email.com", Name = "Joel Santana"};

            using (var dbContext = new ContextHelper())
            {
                dbContext.Coaches.Add(newCoach);
                dbContext.SaveChanges();
            }
        
            using (var dbContext = new ContextHelper())
            {
                dbContext.Coaches.Find(newCoach.Id).ShouldBeEquivalentTo(newCoach);
            }
        }

        [TestMethod]
        public void CoachAthetesAreCorrectlySaved()
        {
            var newCoach = new Coach { Email = "coach@email.com", Name = "Joel Santana" };
            var newAthlete = new Athlete { Name = "Zico", Email = "zico@flamengo.com.br" };
            newCoach.AddAthlete(newAthlete);

            using (var dbContext = new ContextHelper())
            {
                dbContext.Coaches.Add(newCoach);
                dbContext.SaveChanges();
            }

            using (var dbContext = new ContextHelper())
            {
                dbContext.Coaches.Find(newCoach.Id).GetAthletes().Should().Contain(newAthlete);
            }
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
