using SportStats.Models.Base;

namespace SportStats.Models
{
    public class Team : BaseEntity
    {
        String? Location { get; set; }

        int Prestige { get; set; }
    }
}
