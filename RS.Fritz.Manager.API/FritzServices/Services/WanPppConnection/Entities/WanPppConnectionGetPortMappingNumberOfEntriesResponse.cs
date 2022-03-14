﻿namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetPortMappingNumberOfEntriesResponse")]
public sealed record WanPppConnectionGetPortMappingNumberOfEntriesResponse
{
    [MessageBodyMember(Name = "NewPortMappingNumberOfEntries")]
    public ushort PortMappingNumberOfEntries { get; set; }
}