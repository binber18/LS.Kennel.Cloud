namespace LS.Kennel.Cloud.Models;

public class Heat : Entity
{
    public DateTime Start { get; set; }
    public DateTime? End { get; set; }
    public List<Mating> Matings { get; set; } = new();
    public List<ProgesteroneTest> ProgesteroneTests { get; set; } = new();
    public List<Dog> Puppies { get; set; } = new();
    public Guid DogId { get; set; }
    public Dog? Dog { get; set; }
}