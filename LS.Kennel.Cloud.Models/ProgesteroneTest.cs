namespace LS.Kennel.Cloud.Models;

public class ProgesteroneTest : Entity
{
    public DateTime TestTime { get; set; } = DateTime.Now;
    public double Value { get; set; }
    public Guid HeatId { get; set; }
    public Heat? Heat { get; set; }
}