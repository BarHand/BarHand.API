using System.ComponentModel.DataAnnotations;

namespace BarHand.API.Stores.Resources;

public class UpdateStoreResource
{
    
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }
    [Required]  
    [MaxLength(200)]
    public string LastName { get; set; }
    [Required]
    [MaxLength(200)]
    public string StoreName { get; set; }
    [Required]
    [MaxLength(200)]
    public string Email { get; set; }
    [Required]
    [MaxLength(200)]
    public string Password { get; set; }
    
    public string Image { get; set; }
    public long Phone { get; set; }
    public string Address { get; set; }
}