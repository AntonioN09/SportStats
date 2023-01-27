using SportStats.Models.Base;

namespace SportStats.Models
{
    public class Event : BaseEntity
    {
        public String? Location { get; set; }

        public String Summary { get; set; }

        public ICollection<TeamInEvent> TeamsInEvents { get; set; }
    }
}
