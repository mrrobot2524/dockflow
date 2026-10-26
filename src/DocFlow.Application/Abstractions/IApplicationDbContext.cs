using DocFlow.Domain.OrgStructure;

using Microsoft.EntityFrameworkCore;

namespace DocFlow.Application.Abstractions;

public interface IApplicationDbContext
{
    DbSet<OrgUnit> OrgUnits { get; }
    DbSet<User> Users { get; }
    DbSet<Role> Roles { get; }
    DbSet<Assignment> Assignments { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}