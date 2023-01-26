using System.ComponentModel.DataAnnotations;

namespace LS.Kennel.Cloud.Models.Requests;

public class CreateKennelRequest
{
    [Required(AllowEmptyStrings = false)]
    public string Name { get; set; } = string.Empty;
}