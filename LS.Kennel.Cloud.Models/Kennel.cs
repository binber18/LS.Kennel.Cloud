namespace LS.Kennel.Cloud.Models;

public class Kennel : Entity
{
    public string Name { get; set; } = string.Empty;
    public List<Dog> Dogs { get; set; } = new();
    public List<KennelOwnership> Owners { get; set; } = new();
}