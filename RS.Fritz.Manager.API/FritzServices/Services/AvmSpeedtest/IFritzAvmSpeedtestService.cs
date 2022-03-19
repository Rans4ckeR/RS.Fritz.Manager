namespace RS.Fritz.Manager.API;

using System.ServiceModel;
using System.Threading.Tasks;

[ServiceContract(Namespace = "urn:dslforum-org:service:X_AVM-DE_Speedtest:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzAvmSpeedtestService
{
    [OperationContract(Action = "urn:dslforum-org:service:X_AVM-DE_Speedtest:1#GetInfo")]
    public Task<AvmSpeedtestGetInfoResponse> GetInfoAsync(AvmSpeedtestGetInfoRequest avmSpeedtestGetInfoRequest);
}