namespace RS.Fritz.Manager.API
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetDSLInfo")]
#pragma warning disable S101 // Types should be named in PascalCase
    public sealed record WanDslInterfaceConfigGetDSLInfoRequest;
#pragma warning restore S101 // Types should be named in PascalCase
}