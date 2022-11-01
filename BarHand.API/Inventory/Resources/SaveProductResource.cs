using System.ComponentModel.DataAnnotations;

namespace BarHand.API.Inventory.Resources;

public class SaveProductResource
{
    [Required]
    public string Name { get; set; }
}