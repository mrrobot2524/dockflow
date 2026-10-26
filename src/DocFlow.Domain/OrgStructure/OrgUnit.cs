namespace DocFlow.Domain.OrgStructure;

public class OrgUnit
{
    public Guid Id { get; private set; } = Guid.CreateVersion7();
    public string Name { get; private set; } = null!;
    public OrgUnitType Type { get; private set; }
    public Guid? ParentId { get; private set; }
    public OrgUnit? Parent { get; private set; }
    public List<OrgUnit> Children { get; private set; } = [];
    public List<Assignment> Assignments { get; private set; } = [];
    
    private OrgUnit(){}

    public static OrgUnit Create(string name, OrgUnitType type, Guid? parentId = null)
    {
        if(string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Название подразделения обязательно ", nameof(name));

        if (type == OrgUnitType.Academy && parentId is not null)
            throw new InvalidOperationException("Академия - корневое подразделение, родителя бить не может");

        if (type != OrgUnitType.Academy && parentId is not null)
            throw new InvalidOperationException("Отделение и кафедра должны иметь родителя");

        return new OrgUnit { Name = name.Trim(), Type = type, ParentId = parentId };
    }
}