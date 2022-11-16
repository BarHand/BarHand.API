using System.ComponentModel.DataAnnotations;

namespace BarHand.API.Suppliers.Resources;

public class SaveSupplierResource
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }
    [Required]
    [MaxLength(200)]
    public string LastName { get; set; }
    [Required]
    [MaxLength(200)]
    public string SupplierName { get; set; }
    [Required]
    [MaxLength(200)]
    public string Email { get; set; }
    [Required]
    [MaxLength(200)]
    public string Password { get; set; }
}