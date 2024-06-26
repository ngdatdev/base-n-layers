using System;
using DataAccess.Entities.Base;

namespace DataAccess.Entities;

/// <summary>
///     Represent the "Roles" table.
/// </summary>
public class RoleDetail : IBaseEntity, ICreatedEntity, IUpdatedEntity, ITemporarilyRemovedEntity
{
    // Primary keys.
    // Foreign keys.
    public Guid RoleId { get; set; }

    // Normal columns.
    public DateTime UpdatedAt { get; set; }

    public Guid UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime RemovedAt { get; set; }

    public Guid RemovedBy { get; set; }

    // Navigation properties.
    public Role Role { get; set; }
}
