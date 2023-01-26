namespace SportStats.Models.Base
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }

        String? Name { get; set; }

        int Rating { get; set; }

        int Awards { get; set; } 
    }
}
