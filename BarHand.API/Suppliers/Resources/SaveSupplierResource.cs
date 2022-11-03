using System.ComponentModel.DataAnnotations;

namespace BarHand.API.Suppliers.Resources;

public class SaveSupplierResource
{
    [Required]
    [MaxLength(200)]
    public string SupplierName { get; set; }
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }
    [Required]
    [MaxLength(200)]
    public string LastName { get; set; }
    [Required]
    [MaxLength(200)]
    public string Email { get; set; }
    [MaxLength(200)]
    public string Address { get; set; }
    [Required]
    public long Ruc { get; set; }
    [MaxLength(200)]
    public string Category { get; set; }
    [Required]
    [MaxLength(200)]
    public string Description { get; set; }
    [Required]
    public long Phone { get; set; }
    [Required]
    [MaxLength(200)]
    public string Password { get; set; }
    [Required]
    public long Likes { get; set; } 
}