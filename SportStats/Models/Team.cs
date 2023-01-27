using SportStats.Models.Base;

namespace SportStats.Models
{
    public class Team : BaseEntity
    {
        public String? Location { get; set; }

        public int Prestige { get; set; }

        public ICollection<Player> Players { get; set; }

        public ICollection<TeamInEvent> TeamsInEvents { get; set; }

        public Manager Manager { get; set;}

        public Guid ManagerId { get; set; }
    }
}
