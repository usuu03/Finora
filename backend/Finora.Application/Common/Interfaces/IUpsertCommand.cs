using System;

namespace Finora.Application.Common.Interfaces;

public interface IUpsertCommand<TEntity>
{
    Guid Id { get; set; }
    void CopyProperties(TEntity model);
    void MergeProperties(TEntity model);

}