using Finora.Domain.Common.Interfaces;

namespace Finora.Application.Common.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> FilterActive<T>(this IQueryable<T> query) where T : class, IHaveSoftDelete
    {
        return query.Where(x => x.DeletedAt == null);
    }

}
