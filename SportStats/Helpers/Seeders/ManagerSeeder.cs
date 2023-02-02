using SportStats.Data;
using SportStats.Models;

namespace SportStats.Helpers.Seeders
{
    public class ManagerSeeder
    {
        private readonly SportStatsContext _sportStatsContext;

        public ManagerSeeder(SportStatsContext sportStatsContext)
        {
            _sportStatsContext = sportStatsContext;
        }

        public void SeedInitialManagers()
        {
            if (!_sportStatsContext.Managers.Any())
            {
                var manager1 = new Manager
                {
                    Name = "Jose Mourinho",
                    Rating = 8,
                    Awards = 20, 
                    Style = "Defensive",
                    Tactics = 10
                };
                var manager2 = new Manager
                {
                    Name = "Pep Guardiola",
                    Rating = 9,
                    Awards = 30,
                    Style = "Possession + pass accuracy",
                    Tactics = 9
                };

                _sportStatsContext.Managers.Add(manager1);
                _sportStatsContext.Managers.Add(manager2);

                _sportStatsContext.SaveChanges();
            }
        }
    }
}
