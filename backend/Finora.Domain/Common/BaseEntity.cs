using System;

namespace Finora.Domain.Common;

public abstract class BaseEntity<TEntity> where TEntity : BaseEntity<TEntity>
{ 
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime DeletedAt { get; set; }

    public abstract bool Equals(TEntity? other);

}
