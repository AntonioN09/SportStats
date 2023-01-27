using SportStats.Models.Base;

namespace SportStats.Models
{
    public class Player : BaseEntity
    {
        public int Cooperation { get; set; }

        public int Skill { get; set; }

        public Team Team { get; set; }

        public Guid TeamId { get; set; }    
    }
}
