namespace RS.Fritz.Manager.API;

using System.ServiceModel.Channels;

internal sealed class FritzDeviceConfigService(Binding binding, EndpointAddress remoteAddress)
    : ClientBase<IFritzDeviceConfigService>(binding, remoteAddress), IFritzDeviceConfigService
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