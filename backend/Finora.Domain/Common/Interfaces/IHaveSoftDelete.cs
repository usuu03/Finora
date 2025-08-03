namespace Finora.Domain.Common.Interfaces;

public interface IHaveSoftDelete
{
    DateTime? DeletedAt { get; set; }

}
