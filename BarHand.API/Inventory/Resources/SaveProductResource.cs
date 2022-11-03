using System.ComponentModel.DataAnnotations;

namespace BarHand.API.Inventory.Resources;

public class SaveProductResource
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }
    [Required]
    [MaxLength(200)]
    public string Category { get; set; }
    [Required]
    [MaxLength(200)]
    public string Description { get; set; }
    [Required]
    public int NumberOfSales { get; set; }
    [Required]
    public bool Available { get; set; }
    [Required]
    public long SupplierId { get; set; }
}