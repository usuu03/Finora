using System;

namespace Finora.Domain.Common;

public class BaseEntity<TEntity>
{
    Guid Id { get; set; }
    DateTime CreatedAt { get; set; }
    DateTime DeletedAt { get; set; }
}
