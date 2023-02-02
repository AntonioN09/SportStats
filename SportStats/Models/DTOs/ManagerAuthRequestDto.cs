using System.ComponentModel.DataAnnotations;

namespace SportStats.Models.DTOs
{
    public class ManagerAuthRequestDto
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
