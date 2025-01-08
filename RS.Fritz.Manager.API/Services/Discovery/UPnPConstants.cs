namespace RS.Fritz.Manager.API;

public static class UPnPConstants
{
    public const string AvmServiceNamespace = $"{AvmNamespace}:{Service}";
    public const string InternetGatewayDeviceNamespace = $"{DeviceNamespace}:{InternetGatewayDevice}";
    public const string InternetGatewayDeviceAvmNamespace = $"{DeviceAvmNamespace}:{InternetGatewayDevice}";
    public const string InternetGatewayDeviceV1DeviceType = $"{InternetGatewayDeviceNamespace}:1";
    public const string InternetGatewayDeviceV2DeviceType = $"{InternetGatewayDeviceNamespace}:2";
    public const string InternetGatewayDeviceV1AvmDeviceType = $"{InternetGatewayDeviceAvmNamespace}:1";
    public const ushort MultiCastPort = 1900;
    public const ushort AvmPort = 49000;
    public const string AllDeviceTypes = "ssdp:all";
    public const string RootDeviceDeviceType = "upnp:rootdevice";
    internal const string Root = "root";
    internal const string Device = "device";
    internal const string Icon = "icon";
    internal const string Service = "service";
    internal const string SpecVersion = "specVersion";
    internal const string SystemVersion = "systemVersion";
    internal const string Control10Namespace = $"{ControlNamespace}-1-0";
    internal const string Control10AvmNamespace = $"{ControlAvmNamespace}-1-0";
    internal const string Device10Namespace = $"{DeviceNamespace}-1-0";
    internal const string Device10AvmNamespace = $"{DeviceAvmNamespace}-1-0";
    internal const string ServiceNamespace = $"{Namespace}:{Service}";
    private const string Namespace = "urn:schemas-upnp-org";
    private const string AvmNamespace = "urn:dslforum-org";
    private const string Control = "control";
    private const string ControlNamespace = $"{Namespace}:{Control}";
    private const string ControlAvmNamespace = $"{AvmNamespace}:{Control}";
    private const string DeviceNamespace = $"{Namespace}:{Device}";
    private const string DeviceAvmNamespace = $"{AvmNamespace}:{Device}";
    private const string InternetGatewayDevice = "InternetGatewayDevice";
}