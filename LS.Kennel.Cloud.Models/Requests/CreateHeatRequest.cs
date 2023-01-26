namespace LS.Kennel.Cloud.Models.Requests;

public class CreateHeatRequest
{
    public Guid DogId { get; set; }
    public DateTime Start { get; set; }
}