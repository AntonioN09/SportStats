using SportStats.Models.Base;
using SportStats.Models.Enums;
using System.Text.Json.Serialization;

namespace SportStats.Models
{
    public class Manager : BaseEntity
    {
        public String Style { get; set; }

        public int Tactics { get; set; }

        public Team Team { get; set; }

        public Role Role { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
