namespace MyWorkoutProgress.Domain.Entities;

public class EntityBase
{
    public int Id { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}
