namespace DocFlow.Domain.OrgStructure;

public class Assignment
{
    public Guid Id { get; private set; } = Guid.CreateVersion7();
    public Guid UserId { get; private set; }
    public User User { get; private set; } = null!;
    public Guid RoleId { get; private set; }
    public Role Role { get; private set; }
    public Guid OrgUnitId { get; private set; }
    public OrgUnit OrgUnit { get; private set; } = null!;
    public DateOnly StartedOn { get; private set; }
    public DateOnly? EndedOn { get; private set; }
    
    private Assignment(){}

    public static Assignment Create(User user, Role role, OrgUnit orgUnit, DateOnly startedOn)
    {
        return new Assignment { User = user, Role = role, OrgUnit = orgUnit, StartedOn = startedOn };
    }

    public bool IsActiveOn(DateOnly date) =>
        StartedOn <= date && (EndedOn is null || EndedOn >= date);

    public void End(DateOnly endedOn)
    {
        if (endedOn < StartedOn)
            throw new InvalidOperationException("Дата окончания не может быть раньше даты начала");

        EndedOn = endedOn;
    }
}