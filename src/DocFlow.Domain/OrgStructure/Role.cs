namespace DocFlow.Domain.OrgStructure;

public class Role
{
    public Guid Id { get; private set; } = Guid.CreateVersion7();
    public string Name { get; private set; } = null!;
    
    private Role() {}

    public static Role Create(string name)
    {
        if(string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Название роли обязательно ", nameof(name));

        return new Role { Name = name.Trim() };
    }
}