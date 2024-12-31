using System.Net;
using Microsoft.Extensions.Logging;

namespace RS.Fritz.Manager.API;

internal sealed class FritzDeviceConfigService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential, ILoggerFactory loggerFactory)
    : FritzServiceClient<IFritzDeviceConfigService>(endpointConfiguration, remoteAddress, networkCredential, loggerFactory), IFritzDeviceConfigService
{
    public Task<DeviceConfigGetPersistentDataResponse> GetPersistentDataAsync(DeviceConfigGetPersistentDataRequest deviceConfigGetPersistentDataRequest)
        => Channel.GetPersistentDataAsync(deviceConfigGetPersistentDataRequest);

    public Task<DeviceConfigGenerateUuIdResponse> GenerateUuIdAsync(DeviceConfigGenerateUuIdRequest deviceConfigGenerateUuIdRequest)
        => Channel.GenerateUuIdAsync(deviceConfigGenerateUuIdRequest);

    public Task<DeviceConfigCreateUrlSidResponse> CreateUrlSidAsync(DeviceConfigCreateUrlSidRequest deviceConfigCreateUrlSidRequest)
        => Channel.CreateUrlSidAsync(deviceConfigCreateUrlSidRequest);

    public Task<DeviceConfigGetSupportDataInfoResponse> GetSupportDataInfoAsync(DeviceConfigGetSupportDataInfoRequest deviceConfigGetSupportDataInfoRequest)
        => Channel.GetSupportDataInfoAsync(deviceConfigGetSupportDataInfoRequest);

    public Task<DeviceConfigGetConfigFileResponse> GetConfigFileAsync(DeviceConfigGetConfigFileRequest deviceConfigGetConfigFileRequest)
        => Channel.GetConfigFileAsync(deviceConfigGetConfigFileRequest);
}