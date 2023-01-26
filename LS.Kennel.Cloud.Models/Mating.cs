namespace LS.Kennel.Cloud.Models;

public class Mating : Entity
{
    public Guid HeatId { get; set; }
    public Heat? Heat { get; set; }

    public Guid MaleId { get; set; }
    public Dog? Male { get; set; }

    public Guid FemaleId { get; set; }
    public Dog? Female { get; set; }
    
    public DateTime TimeStamp { get; set; }
}