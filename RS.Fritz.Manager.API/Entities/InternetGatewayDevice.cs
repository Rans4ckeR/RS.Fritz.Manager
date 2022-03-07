namespace RS.Fritz.Manager.API
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Serialization;

    public sealed record InternetGatewayDevice(IFritzServiceOperationHandler FritzServiceOperationHandler, IEnumerable<Uri> Locations, string Server, string CacheControl, string? Ext, string SearchTarget, string UniqueServiceName, Uri PreferredLocation)
    {
        public UPnPDescription? UPnPDescription { get; set; }

        public ushort? SecurityPort { get; set; }

        public User[]? Users { get; set; }

        public NetworkCredential? NetworkCredential { get; set; }

        public async Task<TResult> ExecuteAsync<TResult>(Func<IFritzServiceOperationHandler, InternetGatewayDevice, Task<TResult>> operation)
        {
            await InitializeAsync();

            return await operation(FritzServiceOperationHandler, this);
        }

        public async Task InitializeAsync()
        {
            if (SecurityPort is not null)
                return;

            SecurityPort = (await FritzServiceOperationHandler.DeviceInfoGetSecurityPortAsync(this)).SecurityPort;

            LanConfigSecurityGetUserListResponse lanConfigSecurityGetUserListResponse = await FritzServiceOperationHandler.LanConfigSecurityGetUserListAsync(this);

            using var stringReader = new StringReader(lanConfigSecurityGetUserListResponse.UserList);
            using var xmlTextReader = new XmlTextReader(stringReader);

            UserList? userList = (UserList?)new XmlSerializer(typeof(UserList)).Deserialize(xmlTextReader);

            Users = userList?.Users ?? Array.Empty<User>();
        }
    }
}