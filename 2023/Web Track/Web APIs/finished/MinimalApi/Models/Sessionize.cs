namespace MinimalApi.Models;

public class Sessionize
{
    public int GroupId { get; set; }
    public required List<Session> Sessions { get; set; }
}