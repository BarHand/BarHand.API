using System.ComponentModel.DataAnnotations;

namespace BarHand.API.Suppliers.Resources;

public class UpdateSupplierResource
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
    public long Ruc { get; set; }
    [MaxLength(200)]
    public string Category { get; set; }
    
    [MaxLength(200)]
    public string Description { get; set; }
    [MaxLength(300)]
    public string Image { get; set; }
    public long Phone { get; set; }
    [Required]
    [MaxLength(200)]
    public string Password { get; set; }
}