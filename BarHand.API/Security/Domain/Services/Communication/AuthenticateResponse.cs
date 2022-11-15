namespace BarHand.API.Security.Domain.Services.Communication;

public class AuthenticateResponse
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Token { get; set; }
    
}