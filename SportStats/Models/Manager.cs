using SportStats.Models.Base;

namespace SportStats.Models
{
    public class Manager : BaseEntity
    {
        String? Style { get; set; }

        int Tactics { get; set; }
    }
}
