using SportStats.Models.Base;

namespace SportStats.Models
{
    public class Manager : BaseEntity
    {
        public String Style { get; set; }

        public int Tactics { get; set; }

        public Team Team { get; set; }
    }
}
