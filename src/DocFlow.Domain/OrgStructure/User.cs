namespace DocFlow.Domain.OrgStructure;

public class User
{
    public Guid Id { get; private set; } = Guid.CreateVersion7();
    public string FullName { get; private set; } = null!;
    public string Login { get; private set; } = null!;
    public List<Assignment> Assignments { get; private set; } = [];
    
    private User(){}

    public static User Create(string fullName, string login)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("ФИО обязательно ", nameof(fullName));
        
        if(string.IsNullOrWhiteSpace(login))
            throw new ArgumentException("Логин обязателен ", nameof(login));

        return new User { FullName = fullName.Trim(), Login = login.Trim().ToLowerInvariant() };
    }
}