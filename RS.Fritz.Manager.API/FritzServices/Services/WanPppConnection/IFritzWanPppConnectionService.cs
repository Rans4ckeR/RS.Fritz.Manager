﻿namespace RS.Fritz.Manager.API;

using System.ServiceModel;
using System.Threading.Tasks;

[ServiceContract(Namespace = "urn:dslforum-org:service:WANPPPConnection:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWanPppConnectionService
{
    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetInfo")]
    public Task<WanPppConnectionGetInfoResponse> GetInfoAsync(WanPppConnectionGetInfoRequest wanPppConnectionGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetConnectionTypeInfo")]
    public Task<WanPppConnectionGetConnectionTypeInfoResponse> GetConnectionTypeInfoAsync(WanPppConnectionGetConnectionTypeInfoRequest wanPppConnectionGetConnectionTypeInfoRequest);
}