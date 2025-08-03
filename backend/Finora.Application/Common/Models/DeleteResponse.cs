namespace Finora.Application.Common.Models;

public class DeleteResponse
{
    public List<Guid> Success { get; set; } = new();
    public List<Guid> Failed { get; set; } = new();
    public string Message { get; set; } = string.Empty;
    public Dictionary<Guid, string> Errors { get; set; } = new();
}