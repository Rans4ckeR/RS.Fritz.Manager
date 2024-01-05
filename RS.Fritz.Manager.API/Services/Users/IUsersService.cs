namespace RS.Fritz.Manager.API;

public interface IUsersService
{
    ValueTask<IEnumerable<User>> GetUsersAsync(InternetGatewayDevice internetGatewayDevice);
}