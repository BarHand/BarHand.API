using System.ComponentModel.DataAnnotations;

namespace BarHand.API.Security.Domain.Services.Communication;

public class UpdateRequest
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}