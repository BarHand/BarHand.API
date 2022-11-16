using System.ComponentModel.DataAnnotations;

namespace BarHand.API.Security.Domain.Services.Communication;

public class AuthenticateRequest
{
    [Required] public string Name { get; set; }
    [Required] public string Password { get; set; }
}