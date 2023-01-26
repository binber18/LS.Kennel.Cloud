namespace LS.Kennel.Cloud.Models;

public class Dog : Entity
{
    public Guid? HeatId { get; set; }
    public Heat? Heat { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? CallName { get; set; }
    public DateTime BirthDay { get; set; }
    public Guid KennelId { get; set; }
    public Kennel? Kennel { get; set; }
    public List<Heat> Heats { get; set; } = new();
}