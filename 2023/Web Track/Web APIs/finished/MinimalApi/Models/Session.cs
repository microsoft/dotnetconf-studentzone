namespace MinimalApi.Models;

public class Session
{
    public required string Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public DateTime StartsAt { get; init; }
    public DateTime EndsAt { get; init; }
    public required List<Speaker> Speakers { get; init; }
}