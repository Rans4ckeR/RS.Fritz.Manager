using System.Xml;
using System.Xml.Serialization;

namespace RS.Fritz.Manager.API;

internal sealed class UsersService(IFritzServiceOperationHandler fritzServiceOperationHandler) : IUsersService
{
    public async ValueTask<IEnumerable<User>> GetUsersAsync(InternetGatewayDevice internetGatewayDevice)
    {
        LanConfigSecurityGetUserListResponse lanConfigSecurityGetUserListResponse = await fritzServiceOperationHandler.LanConfigSecurityGetUserListAsync(internetGatewayDevice).ConfigureAwait(false);
        using var stringReader = new StringReader(lanConfigSecurityGetUserListResponse.UserList);
        using var xmlTextReader = new XmlTextReader(stringReader);
        var userList = (UserList)new XmlSerializer(typeof(UserList)).Deserialize(xmlTextReader)!;

        return userList.Users;
    }
}