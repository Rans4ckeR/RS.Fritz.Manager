namespace RS.Fritz.Manager.API;

public interface IUsersService
{
    Task<IEnumerable<User>> GetUsersAsync(InternetGatewayDevice internetGatewayDevice);
}