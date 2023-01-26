using SportStats.Models.Base;

namespace SportStats.Models
{
    public class Event : BaseEntity
    {
        String? Location { get; set; }

        String? Summary { get; set; }
    }
}
