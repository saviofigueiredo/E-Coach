using System.Linq;
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

            newCoach.Insert();
        
            var persistedCoach = PersistenceManager.Get().Find(newCoach);
            persistedCoach.ShouldBeEquivalentTo(newCoach);
        }

        [TestMethod]
        public void CoachAthetesAreCorrectlySaved()
        {
            var newCoach = new Coach { Email = "coach@email.com", Name = "Joel Santana" };
            var newAthlete = new Athlete { Name = "Zico", Email = "zico@flamengo.com.br" };
            newCoach.AddAthlete(newAthlete);

            newCoach.Insert();

            var persistedCoach = PersistenceManager.Get().Find(newCoach);
            persistedCoach.Athletes.Should().Contain(newAthlete);
        }

        [TestInitialize]
        public void TestSetup()
        {
            var coaches = PersistenceManager.Get().Coaches().ToList();
            foreach (var coach in coaches)
            {
                coach.Delete();
            }
        }
    }
}
