namespace SportStats.Models.DTOs
{
    public class ManagerAuthResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Token { get; set; }

        public ManagerAuthResponseDto(Manager manager, string token)
        {
            Id = manager.Id;
            Name = manager.Name;
            Token = token;
        }
    }
}
