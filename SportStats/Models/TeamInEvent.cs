namespace SportStats.Models
{
    public class TeamInEvent
    {
        public Guid TeamId { get; set; }

        public Team Team { get; set; }

        public Guid EventId { get; set; }

        public Event Event { get; set; }  
    }
}
