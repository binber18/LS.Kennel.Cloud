using System.ComponentModel.DataAnnotations;

namespace LS.Kennel.Cloud.Models.Requests;

public class CreateDogRequest
{
    [Required(AllowEmptyStrings = false)]
    public string Name { get; set; } = string.Empty;
    public string? CallName { get; set; }
    public DateTime BirthDay { get; set; } = DateTime.Now;
}

public class CreateProgesteroneTestRequest
{
    public DateTime TestTime { get; set; }
    public double Value { get; set; }
}